using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Google.ProtocolBuffers;
using com.gexin.rp.sdk.dto;
using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;
using com.igetui.api.openservice.igetui.template;



namespace HeadacheCDSSWeb.Models
{
    public class Push
    {
        private static String APPID = "fDGJSsU22U7etxd2nUG751";                     //您应用的AppId
        private static String APPKEY = "lwgZ9rlfQoAZOXvpUoeGR5";                    //您应用的AppKey
        private static String MASTERSECRET = "nNClrHv43Y5dMwb6Ec8poA";              //您应用的MasterSecret 
        //private static String CLIENTID = "5081dc638734981f387a3855f7ba09dc";        //您获取的clientID
        private static String HOST = "http://sdk.open.api.igexin.com/apiex.htm";    //HOST：OpenService接口地址

        public string PushAdvice(string strAdvice,string clientID)
        {
            //1.PushMessageToSingle接口
           PushMessageToSingle(clientID);
           string pushResult = PushMessageToSingle(strAdvice,clientID);
           return pushResult;
        }

        //PushMessageToSingle接口测试代码
        private static string PushMessageToSingle(string strAdvice, string clientID)
        {
            // 推送主类
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
          //  LinkTemplate template = LinkTemplateDemo(strAdvice);
            NotificationTemplate notificationTemplate = NotificationTemplateDemo(strAdvice);
            SingleMessage message = new SingleMessage();
            // 用户当前不在线时，是否离线存储,可选
            message.IsOffline = false;
            // 离线有效时间，单位为毫秒，可选
            message.OfflineExpireTime = 1000 * 3600 * 12;
            message.Data = notificationTemplate;
            com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
            target.appId = APPID;
            target.clientId = clientID;
            String pushResult = push.pushMessageToSingle(message, target);
            return pushResult;
        }
        private static string PushMessageToSingle(string clientID)
        {
            // 推送主类
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            //  LinkTemplate template = LinkTemplateDemo(strAdvice); 
            TransmissionTemplate transmissionTemplate = TransmissionTemplateDemo();
            SingleMessage message = new SingleMessage();
            // 用户当前不在线时，是否离线存储,可选
            message.IsOffline = false;
            // 离线有效时间，单位为毫秒，可选
            message.OfflineExpireTime = 1000 * 3600 * 12;
            message.Data = transmissionTemplate;

            com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
            target.appId = APPID;
            target.clientId = clientID;
            String pushResult = push.pushMessageToSingle(message, target);
            return pushResult;
        }

        public static NotificationTemplate NotificationTemplateDemo(string strAdvice)
        {
            NotificationTemplate template = new NotificationTemplate();
            template.AppId = APPID;
            template.AppKey = APPKEY;
            //通知栏标题
            template.Title = "来自的医生意见";
            //通知栏内容    
            template.Text =strAdvice;
            //通知栏显示本地图片	
            template.Logo = "";
            //通知栏显示网络图标
            template.LogoURL = "";
            //应用启动类型，1：强制应用启动  2：等待应用启动	
            template.TransmissionType = "1";
            //透传内容
            template.TransmissionContent = "";
            //接收到消息是否响铃，true：响铃 false：不响铃
            template.IsRing = true;
            //接收到消息是否震动，true：震动 false：不震动
            template.IsVibrate = true;
            //接收到消息是否可清除，true：可清除 false：不可清除
            template.IsClearable = true;
            return template;
        }
        public static TransmissionTemplate TransmissionTemplateDemo()
        {
            TransmissionTemplate template = new TransmissionTemplate();
            template.AppId = APPID;
            template.AppKey = APPKEY;
            //应用启动类型，1：强制应用启动 2：等待应用启动
            template.TransmissionType = "2";
            //透传内容	
            template.TransmissionContent = "您有一条新消息";
            template.setPushInfo("actionLocKey", 4, "message", "sound",
            "payload", "locKey", "locArgs", "launchImage");
            /*IOS 推送需要对该字段进行设置具体参数详见2.5*/
            return template;
        }
    }
}