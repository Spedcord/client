using System;
using System.Linq;
using Newtonsoft.Json;

namespace SpedcordClient.api
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

        [JsonProperty("memberLimit")] public int MemberLimit { get; set; }

        [JsonProperty("purchasedItems")] public int[] PurchasedItems { get; set; }

        //[JsonProperty("logbook")] public Logbook Logbook { get; set; }

        public Role GetRole(long member)
        {
            var rolee = Roles == null ? null : Roles.FirstOrDefault(role => role.MemberDiscordIds.Contains(member));
            return rolee == null ? new Role(){Name = "", Payout = 0, Permissions = 0, MemberDiscordIds = new long[0]} : rolee;
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
            Administrator = 0x0001,
            EditCompany = 0x0002,
            ManageMembers = 0x0004,
            ManageRoles = 0x0008,
            BuyItems = 0x0010
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