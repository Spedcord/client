﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace SpedcordClient
{
    public partial class Company
    {
        [JsonProperty("discordServerId")] public long DiscordServerId { get; set; }

        [JsonProperty("ownerDiscordId")] public long OwnerDiscordId { get; set; }

        [JsonProperty("memberDiscordIds")] public long[] MemberDiscordIds { get; set; }

        [JsonProperty("roles")] public Role[] Roles { get; set; }

        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("balance")] public double Balance { get; set; }

        [JsonProperty("defaultRole")] public string DefaultRole { get; set; }

        [JsonProperty("rank")] public int Rank { get; set; }

        [JsonProperty("logbook")] public Logbook Logbook { get; set; }

        public Role GetRole(long member)
        {
            return Roles.FirstOrDefault(role => role.MemberDiscordIds.Contains(member));
        }

        public bool HasPermission(long member, Role.Permission permission)
        {
            var role = GetRole(member);
            return role != null && Role.PermissionMethods.HasPermission(role.Permissions, permission);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public partial class Logbook
    {
    }

    public partial class Role
    {
        [JsonProperty("memberDiscordIds")] public long[] MemberDiscordIds { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("payout")] public double Payout { get; set; }

        [JsonProperty("permissions")] public int Permissions { get; set; }

        [Flags]
        public enum Permission
        {
            Administrator = 0x01,
            EditCompany = 0x02,
            ManageMembers = 0x04,
            ManageRoles = 0x08
        }

        public static class PermissionMethods
        {
            public static bool HasPermission(int permInt, Permission permission)
            {
                if (permission != Permission.Administrator && HasPermission(permInt, Permission.Administrator))
                {
                    return true;
                }

                return (permInt & (int) permission) == (int) permission;
            }

            public static int Calculate(params Permission[] permissions)
            {
                return permissions.Aggregate(0, (current, permission) => current | (int) permission);
            }
        }
    }
}