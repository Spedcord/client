using System;
using System.Collections.Generic;
using System.Text;

namespace SpedcordClient.discord
{
    public partial class LobbyManager
    {
        public IEnumerable<User> GetMemberUsers(Int64 lobbyID)
        {
            var memberCount = MemberCount(lobbyID);
            var members = new List<User>();
            for (var i = 0; i < memberCount; i++)
            {
                members.Add(GetMemberUser(lobbyID, GetMemberUserId(lobbyID, i)));
            }
            return members;
        }

        public void SendLobbyMessage(Int64 lobbyID, string data, SpedcordClient.discord.LobbyManager.SendLobbyMessageHandler handler)
        {
            SendLobbyMessage(lobbyID, Encoding.UTF8.GetBytes(data), handler);
        }
    }
}
