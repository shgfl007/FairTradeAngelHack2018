using UnityEngine;

public class SendMessage : MonoBehaviour
{
    AndroidJavaObject currentActivity;
    string phoneNumber;
    string linkContent = "http://www.fairtrade.org";
    const string _d_confirmed = "/D_offer_confirm";
    const string _r_confirmed = "/R_offer_confirm";
    const string _d_offer = "/offers";

    string textContent;
    const string _clickToConfirm = ". Click the link to confirm:";
    const string _d_sendOffer = " would like to fair trade with you:";
    const string _done_trade = "Your trade is completed.";
    public void Send_D_confirm(string phone)
    {
        phoneNumber = phone;
        linkContent += _d_confirmed;
        textContent = _done_trade;
        if (Application.platform == RuntimePlatform.Android)
        {
            RunAndroidUiThread();
        }
    }

    public void Send_offers(string phone)
    {
        linkContent += _d_offer;
        textContent = sessionGlobalParams.instance.getDonorName() + _d_sendOffer 
                                         + sessionGlobalParams.instance.getTradeObjectName() + " for "
                                         + sessionGlobalParams.instance.getTradeFoodName() + _clickToConfirm; 
        phoneNumber = phone;
        if (Application.platform == RuntimePlatform.Android)
        {
            RunAndroidUiThread();
        }
    }

    public void Send_R_confirm(string phone)
    {
        linkContent += _r_confirmed;
        phoneNumber = phone;
        textContent = _done_trade;
        if (Application.platform == RuntimePlatform.Android)
        {
            RunAndroidUiThread();
        }

    }

    public void Send(string phone)
    {
        phoneNumber = phone;
        if (Application.platform == RuntimePlatform.Android)
        {
            RunAndroidUiThread();
        }
    }

    public void Send()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            RunAndroidUiThread();
        }
    }

    void RunAndroidUiThread()
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(SendProcess));
    }

    void SendProcess()
    {
        Debug.Log("Running on UI thread");
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");

        // SMS Information

        //string phone = "64780889999";
        string phone = phoneNumber;
        string text = textContent + linkContent;
        string alert;

        try
        {
            // SMS Manager

            AndroidJavaClass SMSManagerClass = new AndroidJavaClass("android.telephony.SmsManager");
            AndroidJavaObject SMSManagerObject = SMSManagerClass.CallStatic<AndroidJavaObject>("getDefault");
            SMSManagerObject.Call("sendTextMessage", phone, null, text, null, null);

            alert = "Message sent successfully.";
        }
        catch (System.Exception e)
        {
            Debug.Log("Error : " + e.StackTrace.ToString());

            alert = "Error has been Occurred. Fail to send message.";
        }

        // Show Toast

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", alert);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }
}