namespace Commun.Logs
{
    public class EnviarLog
    {
        //private static void ConfigureRollbarSingleton()
        //{
        //    RollbarInfrastructureConfig rollbarInfrastructureConfig = new RollbarInfrastructureConfig(
        //        RollbarSettings.AccessToken,
        //        RollbarSettings.Environment
        //        );

        //    RollbarDataSecurityOptions dataSecurityOptions = new RollbarDataSecurityOptions();
        //    dataSecurityOptions.ScrubFields = new string[]
        //    {
        //        "access_token",
        //        "username",
        //    };
        //    rollbarInfrastructureConfig.RollbarLoggerConfig.RollbarDataSecurityOptions.Reconfigure(dataSecurityOptions);

        //    RollbarPayloadAdditionOptions payloadAdditionOptions = new RollbarPayloadAdditionOptions();
        //    payloadAdditionOptions.Person = new Person("007")
        //    {
        //        UserName = RollbarSettings.UserName,
        //        Email = RollbarSettings.Email
        //    };
        //    rollbarInfrastructureConfig.RollbarLoggerConfig.RollbarPayloadAdditionOptions.Reconfigure(payloadAdditionOptions);

        //    RollbarInfrastructure.Instance.Init(rollbarInfrastructureConfig);

        //    // optionally, if you would like to monitor all Rollbar instances' internal events within your application:
        //    RollbarInfrastructure.Instance.QueueController.InternalEvent += OnRollbarInternalEvent;

        //    // optionally, if you would like to monitor this Rollbar instance's internal events within your application:
        //    //RollbarLocator.RollbarInstance.InternalEvent += OnRollbarInternalEvent;
        //}

        //private static void OnRollbarInternalEvent(object sender, RollbarEventArgs e)
        //{
        //    Console.WriteLine(e.TraceAsString());

        //    RollbarApiErrorEventArgs apiErrorEvent = e as RollbarApiErrorEventArgs;
        //    if (apiErrorEvent != null)
        //    {
        //        //TODO: handle/report Rollbar API communication error event...
        //        return;
        //    }
        //    CommunicationEventArgs commEvent = e as CommunicationEventArgs;
        //    if (commEvent != null)
        //    {
        //        //TODO: handle/report Rollbar API communication event...
        //        return;
        //    }
        //    CommunicationErrorEventArgs commErrorEvent = e as CommunicationErrorEventArgs;
        //    if (commErrorEvent != null)
        //    {
        //        //TODO: handle/report basic communication error while attempting to reach Rollbar API service... 
        //        return;
        //    }
        //    InternalErrorEventArgs internalErrorEvent = e as InternalErrorEventArgs;
        //    if (internalErrorEvent != null)
        //    {
        //        //TODO: handle/report basic internal error while using the Rollbar Notifier... 
        //        return;
        //    }
        //}

        //public void EnviarExcepcion(string vMetodoError, System.Exception vExepcion)
        //{
        //    ConfigureRollbarSingleton();

        //    RollbarLocator.RollbarInstance
        //           .AsBlockingLogger(TimeSpan.FromMilliseconds(10000))
        //           .Error(new ApplicationException(vMetodoError + " : ", vExepcion));
        //}
    }
}
