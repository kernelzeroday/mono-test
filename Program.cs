namespace IrcDotNet
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: efnet <username>");
                Console.WriteLine("Demo program (c) Kelsey 2022");
                return;
            }
            var server = new System.Uri("irc://irc.efnet.org");
            var username = args[0];
            Console.WriteLine("Connecting to {0} as {1}", server, username);
            using (var client = new IrcDotNet.StandardIrcClient())
            {
                client.Connect(server, new IrcUserRegistrationInfo { NickName = username, UserName = username, RealName = "Kelsey" });
                client.Connected += (sender, e) =>
                {
                    Console.WriteLine("Connected to {0}", server);
                    client.LocalUser.SendMessage("#test", "Hello world!");
                };
            }
        }
    }
}