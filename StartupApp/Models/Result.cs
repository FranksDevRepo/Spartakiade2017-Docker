namespace StartupApp.Models
{
    public class Result
    {
        public Result()
        {
            RabbitMqState = TestState.Unknown;
            
        }

        public TestState RabbitMqState { get; set; }
    }
}
