using System.Diagnostics;
using System.Timers;

namespace SpedcordClient.discord
{
    public class DiscordController
    {
        private readonly Discord _discord;
        private readonly Timer _loop;

        public DiscordController(long oauthClientId)
        {
            _discord = new Discord(oauthClientId, (ulong) CreateFlags.NoRequireDiscord);
            _loop = new Timer(100);

            _loop.Elapsed += (sender, args) => _discord.RunCallbacks();
            _loop.Disposed += (sender, args) => _discord.Dispose();
            _loop.Start();
        }

        public void UpdateActivity(bool onJob, long jobStart, string state)
        {
            Debug.WriteLine("Discord Activity Update: {0} {1} {2}", onJob, jobStart, state);

            var activityManager = _discord.GetActivityManager();
            activityManager.UpdateActivity(new Activity
            {
                Details = onJob ? "On a job" : "Idle",
                Timestamps = new ActivityTimestamps {Start = jobStart},
                Type = ActivityType.Playing,
                Name = "Spedcord Client",
                State = state,
                Assets = new ActivityAssets
                {
                    LargeText = "Spedcord",
                    LargeImage = "logo_big"
                }
            }, result => { Debug.WriteLine("Discord update result: {0}", result); });
        }

        public void Dispose()
        {
            _loop.Stop();
            _loop.Dispose();
        }
    }
}