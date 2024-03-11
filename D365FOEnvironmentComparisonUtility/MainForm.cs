using CsvHelper;
using D365FOEnvironmentComparisonUtility.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.IO.Compression;

namespace D365FOEnvironmentComparisonUtility
{
    public partial class MainForm : Form
    {
        List<string> doNotProcessFiles;
        ComparisonOverview overview;
        List<ComparisonDetail> details;
        SecurityComparisonDetails securityComparisonDetails;

        public MainForm()
        {
            InitializeComponent();
            doNotProcessFiles = new List<string>
            {
                "SecurityUserRoleAssociation.csv",
                "SecurityUserRoleOrganization.csv",
                "RoleAccess.csv"
            };

            overview = new ComparisonOverview();
            details = new List<ComparisonDetail>();
            securityComparisonDetails = new SecurityComparisonDetails();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            EnvConfig src = LoadEnvConfig(tb_srcFile.Text);
            EnvConfig dest = LoadEnvConfig(tb_destFile.Text);

            CompareUsers(src.Users, dest.Users);
            CompareUserRoles(src.SecurityUserRoles, dest.SecurityUserRoles);
            CompareUserRoleOrgs(src.SecurityUserRoleOrgs, dest.SecurityUserRoleOrgs);

        }

        public void CompareUsers(IEnumerable<User> srcUsers, IEnumerable<User> destUsers)
        {
            foreach (var srcUser in srcUsers)
            {
                var destUser = destUsers.FirstOrDefault(u => string.Equals(srcUser.UserID, u.UserID, StringComparison.CurrentCultureIgnoreCase));

                //User only exists in src environment, was removed from dest environment
                if (destUser == null)
                {
                    overview.RemovedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = srcUser.UserID,
                            ObjectName = srcUser.UserName,
                            ObjectType = "User"
                        });

                    details.Add(new ComparisonDetail
                    {
                        ObjectId = srcUser.UserID,
                        ObjectName = srcUser.UserName,
                        ObjectType = "User",
                        Action = "Removed",
                        OldObject = JsonConvert.SerializeObject(srcUser),
                        OldValue = srcUser.UserID + " - " + srcUser.UserName,
                        NewObject = "-",
                        NewValue = "-"
                    });
                }
                //User exists in both src and dest environments, compare details
                else
                {
                    if (!srcUser.Equals(destUser))
                    {
                        overview.ModifiedObjects.Add(
                                                       new ComparisonOverviewObject
                                                       {
                                                           ObjectId = srcUser.UserID,
                                                           ObjectName = srcUser.UserName,
                                                           ObjectType = "User"
                                                       });

                        if (!string.Equals(srcUser.UserName, destUser.UserName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUser.UserID,
                                ObjectName = srcUser.UserName,
                                ObjectType = "User",
                                Action = "Modified",
                                OldValue = srcUser.UserName,
                                OldObject = JsonConvert.SerializeObject(srcUser),
                                NewValue = destUser.UserName,
                                NewObject = JsonConvert.SerializeObject(destUser)
                            });
                        }
                        if (!string.Equals(srcUser.PersonName, destUser.PersonName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUser.UserID,
                                ObjectName = srcUser.UserName,
                                ObjectType = "User",
                                Action = "Modified",
                                OldValue = srcUser.PersonName,
                                OldObject = JsonConvert.SerializeObject(srcUser),
                                NewValue = destUser.PersonName,
                                NewObject = JsonConvert.SerializeObject(destUser)
                            });
                        }
                        if (!string.Equals(srcUser.Email, destUser.Email, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUser.UserID,
                                ObjectName = srcUser.UserName,
                                ObjectType = "User",
                                Action = "Modified",
                                OldValue = srcUser.Email,
                                OldObject = JsonConvert.SerializeObject(srcUser),
                                NewValue = destUser.Email,
                                NewObject = JsonConvert.SerializeObject(destUser)
                            });
                        }
                        if (!string.Equals(srcUser.Company, destUser.Company, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUser.UserID,
                                ObjectName = srcUser.UserName,
                                ObjectType = "User",
                                Action = "Modified",
                                OldValue = srcUser.Company,
                                OldObject = JsonConvert.SerializeObject(srcUser),
                                NewValue = destUser.Company,
                                NewObject = JsonConvert.SerializeObject(destUser)
                            });
                        }
                        if (!string.Equals(srcUser.Enabled, destUser.Enabled, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUser.UserID,
                                ObjectName = srcUser.UserName,
                                ObjectType = "User",
                                Action = "Modified",
                                OldValue = srcUser.Enabled,
                                OldObject = JsonConvert.SerializeObject(srcUser),
                                NewValue = destUser.Enabled,
                                NewObject = JsonConvert.SerializeObject(destUser)
                            });
                        }
                        if (!string.Equals(srcUser.Alias, destUser.Alias, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUser.UserID,
                                ObjectName = srcUser.UserName,
                                ObjectType = "User",
                                Action = "Modified",
                                OldValue = srcUser.Alias,
                                OldObject = JsonConvert.SerializeObject(srcUser),
                                NewValue = destUser.Alias,
                                NewObject = JsonConvert.SerializeObject(destUser)
                            });
                        }
                    }
                }
            }

            foreach (var destUser in destUsers)
            {
                var srcUser = srcUsers.FirstOrDefault(u => string.Equals(destUser.UserID, u.UserID, StringComparison.CurrentCultureIgnoreCase));

                if (srcUser == null)
                {
                    overview.AddedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = destUser.UserID,
                            ObjectName = destUser.UserName,
                            ObjectType = "User"
                        });

                    details.Add(new ComparisonDetail
                    {
                        ObjectId = destUser.UserID,
                        ObjectName = destUser.UserName,
                        ObjectType = "User",
                        Action = "Added",
                        OldValue = "-",
                        OldObject = "-",
                        NewObject = destUser.UserID + " - " + destUser.UserName,
                        NewValue = JsonConvert.SerializeObject(destUser)
                    });
                }
            }
        }

        public void CompareUserRoles(IEnumerable<SecurityUserRole> srcRoles, IEnumerable<SecurityUserRole> destRoles)
        {
            foreach (var srcRole in srcRoles)
            {
                var destRole = destRoles.FirstOrDefault(r => string.Equals(srcRole.UserId, r.UserId, StringComparison.CurrentCultureIgnoreCase) && string.Equals(srcRole.SecurityRoleIdentifier, r.SecurityRoleIdentifier, StringComparison.CurrentCultureIgnoreCase));

                if (destRole == null)
                {
                    overview.RemovedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = srcRole.UserId,
                            ObjectName = srcRole.SecurityRoleName + " (" + srcRole.SecurityRoleIdentifier + ")",
                            ObjectType = "Security User Role"
                        });

                    details.Add(new ComparisonDetail
                    {
                        ObjectId = srcRole.UserId,
                        ObjectName = srcRole.SecurityRoleName + " (" + srcRole.SecurityRoleIdentifier + ")",
                        ObjectType = "Security User Role",
                        Action = "Removed",
                        OldValue = srcRole.UserId + " - " + srcRole.SecurityRoleName + " (" + srcRole.SecurityRoleIdentifier + ")",
                        OldObject = JsonConvert.SerializeObject(srcRole),
                        NewObject = "-",
                        NewValue = "-"
                    });
                }
                else
                {
                    if (!srcRole.Equals(destRole))
                    {
                        overview.ModifiedObjects.Add(
                            new ComparisonOverviewObject
                            {
                                ObjectId = srcRole.UserId,
                                ObjectName = srcRole.SecurityRoleName,
                                ObjectType = "Security User Role"
                            });

                        if (!string.Equals(srcRole.AssignmentStatus, destRole.AssignmentStatus, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcRole.UserId,
                                ObjectName = srcRole.SecurityRoleName + " (" + srcRole.SecurityRoleIdentifier + ")",
                                ObjectType = "Security User Role",
                                Action = "Modified",
                                OldValue = srcRole.AssignmentStatus,
                                OldObject = JsonConvert.SerializeObject(srcRole),
                                NewValue = destRole.AssignmentStatus,
                                NewObject = JsonConvert.SerializeObject(destRole)
                            });
                        }
                    }
                }
            }

            foreach (var destRole in destRoles)
            {
                var srcRole = srcRoles.FirstOrDefault(r => string.Equals(destRole.UserId, r.UserId, StringComparison.CurrentCultureIgnoreCase) && string.Equals(destRole.SecurityRoleIdentifier, r.SecurityRoleIdentifier, StringComparison.CurrentCultureIgnoreCase));

                if (srcRole == null)
                {
                    overview.AddedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = destRole.UserId,
                            ObjectName = destRole.SecurityRoleName + " (" + destRole.SecurityRoleIdentifier + ")",
                            ObjectType = "Security User Role"
                        });

                    details.Add(new ComparisonDetail
                    {
                        ObjectId = destRole.UserId,
                        ObjectName = destRole.SecurityRoleName + " (" + destRole.SecurityRoleIdentifier + ")",
                        ObjectType = "Security User Role",
                        Action = "Added",
                        OldValue = "-",
                        OldObject = "-",
                        NewObject = destRole.UserId + " - " + destRole.SecurityRoleName + " (" + destRole.SecurityRoleIdentifier + ")",
                        NewValue = JsonConvert.SerializeObject(destRole)
                    });
                }
            }
        }

        public void CompareUserRoleOrgs(IEnumerable<SecurityUserRoleOrganization> srcUserRoleOrgs, IEnumerable<SecurityUserRoleOrganization> destUserRoleOrgs)
        {
            foreach (var srcUserRoleOrg in srcUserRoleOrgs)
            {
                var destUserRoleOrg = destUserRoleOrgs.FirstOrDefault(u => string.Equals(srcUserRoleOrg.UserId, u.UserId, StringComparison.CurrentCultureIgnoreCase) && string.Equals(srcUserRoleOrg.SecurityRoleIdentifier, u.SecurityRoleIdentifier, StringComparison.CurrentCultureIgnoreCase) && string.Equals(srcUserRoleOrg.OrganizationId, u.OrganizationId, StringComparison.CurrentCultureIgnoreCase));

                if (destUserRoleOrg == null)
                {
                    overview.RemovedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = srcUserRoleOrg.UserId,
                            ObjectName = srcUserRoleOrg.SecurityRoleIdentifier + " - " + srcUserRoleOrg.OrganizationId,
                            ObjectType = "Security User Role Organization"
                        });

                    details.Add(new ComparisonDetail()
                    {
                        ObjectId = srcUserRoleOrg.UserId,
                        ObjectName = srcUserRoleOrg.SecurityRoleIdentifier,
                        ObjectType = "Security User Role Organization",
                        Action = "Removed",
                        OldValue = srcUserRoleOrg.OrganizationId,
                        OldObject = JsonConvert.SerializeObject(srcUserRoleOrg),
                        NewValue = "-",
                        NewObject = "-"
                    });
                }
                else
                {
                    if (!srcUserRoleOrg.Equals(destUserRoleOrg))
                    {
                        overview.ModifiedObjects.Add(
                            new ComparisonOverviewObject
                            {
                                ObjectId = srcUserRoleOrg.UserId,
                                ObjectName = srcUserRoleOrg.SecurityRoleIdentifier,
                                ObjectType = "Security User Role Organization"
                            });

                        if (!string.Equals(srcUserRoleOrg.OrganizationType, destUserRoleOrg.OrganizationType, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUserRoleOrg.UserId,
                                ObjectName = srcUserRoleOrg.SecurityRoleIdentifier,
                                ObjectType = "Security User Role Organization",
                                Action = "Modified",
                                OldValue = srcUserRoleOrg.OrganizationType,
                                OldObject = JsonConvert.SerializeObject(srcUserRoleOrg),
                                NewValue = destUserRoleOrg.OrganizationType,
                                NewObject = JsonConvert.SerializeObject(destUserRoleOrg)
                            });
                        }
                        if (!string.Equals(srcUserRoleOrg.OperatingUnitType, destUserRoleOrg.OperatingUnitType, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUserRoleOrg.UserId,
                                ObjectName = srcUserRoleOrg.SecurityRoleIdentifier,
                                ObjectType = "Security User Role Organization",
                                Action = "Modified",
                                OldValue = srcUserRoleOrg.OperatingUnitType,
                                OldObject = JsonConvert.SerializeObject(srcUserRoleOrg),
                                NewValue = destUserRoleOrg.OperatingUnitType,
                                NewObject = JsonConvert.SerializeObject(destUserRoleOrg)
                            });
                        }
                        if (!string.Equals(srcUserRoleOrg.HierarchyType, destUserRoleOrg.HierarchyType, StringComparison.CurrentCultureIgnoreCase))
                        {
                            details.Add(new ComparisonDetail
                            {
                                ObjectId = srcUserRoleOrg.UserId,
                                ObjectName = srcUserRoleOrg.SecurityRoleIdentifier,
                                ObjectType = "Security User Role Organization",
                                Action = "Modified",
                                OldValue = srcUserRoleOrg.HierarchyType,
                                OldObject = JsonConvert.SerializeObject(srcUserRoleOrg),
                                NewValue = destUserRoleOrg.HierarchyType,
                                NewObject = JsonConvert.SerializeObject(destUserRoleOrg)
                            });
                        }
                    }
                }
            }
            foreach (var destUserRoleOrg in destUserRoleOrgs)
            {
                var srcUserRoleOrg = srcUserRoleOrgs.FirstOrDefault(u => string.Equals(destUserRoleOrg.UserId, u.UserId, StringComparison.CurrentCultureIgnoreCase) && string.Equals(destUserRoleOrg.SecurityRoleIdentifier, u.SecurityRoleIdentifier, StringComparison.CurrentCultureIgnoreCase) && string.Equals(destUserRoleOrg.OrganizationId, u.OrganizationId, StringComparison.CurrentCultureIgnoreCase));

                if (srcUserRoleOrg == null)
                {
                    overview.AddedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = destUserRoleOrg.UserId,
                            ObjectName = destUserRoleOrg.SecurityRoleIdentifier + " - " + destUserRoleOrg.OrganizationId,
                            ObjectType = "Security User Role Organization"
                        });

                    details.Add(new ComparisonDetail
                    {
                        ObjectId = destUserRoleOrg.UserId,
                        ObjectName = destUserRoleOrg.SecurityRoleIdentifier,
                        ObjectType = "Security User Role Organization",
                        Action = "Added",
                        OldValue = "-",
                        OldObject = "-",
                        NewObject = destUserRoleOrg.OrganizationId,
                        NewValue = JsonConvert.SerializeObject(destUserRoleOrg)
                    });
                }
            }
        }

        public void CompareSecurity(IEnumerable<RoleAccessDetailed> srcRoleAccess, IEnumerable<RoleAccessDetailed> destRoleAccess)
        {

            IEnumerable<SecurityLayer> srcRoleList = srcRoleAccess.Select(r => new SecurityLayer{ SystemName = r.RoleSystemName, Name = r.RoleName }).Distinct();
            IEnumerable<SecurityLayer> destRoleList = destRoleAccess.Select(r => new SecurityLayer { SystemName = r.RoleSystemName, Name = r.RoleName }).Distinct();

            foreach (var srcRole in srcRoleAccess)
            {
                //Look for removed roles
                var destRole = destRoleAccess.FirstOrDefault(r => string.Equals(srcRole.RoleSystemName, r.RoleSystemName, StringComparison.CurrentCultureIgnoreCase));

                if (destRole == null)
                {
                    overview.RemovedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = srcRole.RoleSystemName,
                            ObjectName = srcRole.RoleName,
                            ObjectType = "Security Role"
                        });

                    var roleAccesses = srcRoleAccess.Where(ra => string.Equals(ra.RoleSystemName, srcRole.RoleSystemName, StringComparison.CurrentCultureIgnoreCase));
                    foreach (var roleAccess in roleAccesses)
                        securityComparisonDetails.RemovedRoleAccess.Add(ConvertRoleAccessToSecurityAccess(roleAccess, null));
                }
                else
                {

                    //Role exists in both src and dest environments, compare details

                    //Get each role access
                    var srcAccess = srcRoleAccess.Where(ra => string.Equals(ra.RoleSystemName, srcRole.RoleSystemName, StringComparison.CurrentCultureIgnoreCase));
                    var destAccess = destRoleAccess.Where(ra => string.Equals(ra.RoleSystemName, srcRole.RoleSystemName, StringComparison.CurrentCultureIgnoreCase));

                    //Convert to hashset for better comparing capabilities
                    HashSet<RoleAccessDetailed> srcRoleAccessesHs = new HashSet<RoleAccessDetailed>(srcRoleAccess);
                    HashSet<RoleAccessDetailed> destRoleAccessesHs = new HashSet<RoleAccessDetailed>(destRoleAccess);

                    //Find the differences
                    HashSet<RoleAccessDetailed> srcDiffRoleAccesses = new HashSet<RoleAccessDetailed>(srcRoleAccess);
                    HashSet<RoleAccessDetailed> destDiffRoleAccesses = new HashSet<RoleAccessDetailed>(destRoleAccess);
                    srcDiffRoleAccesses.ExceptWith(destRoleAccess);
                    destDiffRoleAccesses.ExceptWith(srcRoleAccess);

                    if (srcDiffRoleAccesses.Any() || destDiffRoleAccesses.Any())
                    {
                        //Roles have been modified

                        overview.ModifiedObjects.Add(
                            new ComparisonOverviewObject
                            {
                                ObjectId = srcRole.RoleSystemName,
                                ObjectName = srcRole.RoleName,
                                ObjectType = "Security Role"
                            });


                        HashSet<SecurityAccessChanges> modifiedAccess = new HashSet<SecurityAccessChanges>();
                        foreach (var srcDiffRoleAccess in srcDiffRoleAccesses)
                        {
                            //See if source role access exists in the destination role access
                            var foundAccess = destRoleAccessesHs.FirstOrDefault(ra =>
                                                                               string.Equals(ra.RoleSystemName, srcDiffRoleAccess.RoleSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.SubRoleSystemName, srcDiffRoleAccess.SubRoleSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.DutySystemName, srcDiffRoleAccess.DutySystemName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.PrivilegeSystemName, srcDiffRoleAccess.PrivilegeSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.SecurableObject, srcDiffRoleAccess.SecurableObject, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               ra.SecurableType == srcDiffRoleAccess.SecurableType);

                            //If it does that means the role access has been modified
                            //Adding the destination access to the hashset because we want a distinct list of access changes
                            if (foundAccess != null)
                            {
                                modifiedAccess.Add(ConvertRoleAccessToSecurityAccess(srcDiffRoleAccess, foundAccess));
                            }
                            //If its not found, that means the access to this object existed and now it doesn't
                            //So add it to the removed role access
                            else
                            {
                                securityComparisonDetails.RemovedRoleAccess.Add(ConvertRoleAccessToSecurityAccess(srcDiffRoleAccess, null));
                            }
                        }

                        foreach (var destDiffRoleAccess in destDiffRoleAccesses)
                        {
                            //Now checking the inverse of the first check (loop through destination access and look for source access that's different)
                            var foundAccess = srcRoleAccessesHs.FirstOrDefault(ra =>
                                                                               string.Equals(ra.RoleSystemName, destDiffRoleAccess.RoleSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.SubRoleSystemName, destDiffRoleAccess.SubRoleSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.DutySystemName, destDiffRoleAccess.DutySystemName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.PrivilegeSystemName, destDiffRoleAccess.PrivilegeSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.SecurableObject, destDiffRoleAccess.SecurableObject, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               ra.SecurableType == destDiffRoleAccess.SecurableType);

                            //If we find access that matches, we add the destination access that matches
                            if (foundAccess != null)
                            {
                                modifiedAccess.Add(ConvertRoleAccessToSecurityAccess(foundAccess, destDiffRoleAccess));
                            }
                            //If we don't find the access, that means it was added
                            else
                            {
                                securityComparisonDetails.AddedRoleAccess.Add(ConvertRoleAccessToSecurityAccess(null, destDiffRoleAccess));
                            }
                        }
                        //Now add the distinct modified role access
                        securityComparisonDetails.ModifiedRoleAccess.AddRange(modifiedAccess);
                    }
                }
            }
            //Now look for added roles
            foreach (var destRole in destRoleList)
            {
                var roleFound = srcRoleList.FirstOrDefault(r => string.Equals(r.SystemName, destRole.SystemName, StringComparison.CurrentCultureIgnoreCase));
                if (roleFound == null)
                {

                    securityComparisonDetails.AddedRoles.Add(destRole);

                    //Now find the added role access
                    var roleAccesses = destRoleAccess.Where(ra => string.Equals(ra.RoleSystemName, destRole.SystemName, StringComparison.CurrentCultureIgnoreCase));

                    foreach (var roleAccess in roleAccesses)
                        securityComparisonDetails.AddedRoleAccess.Add(ConvertRoleAccessToSecurityAccess(null, roleAccess));
                }
                //No need to compare role access as we have already done that
            }
        }
    

        #region Helper Methods

        public EnvConfig LoadEnvConfig(string path)
        {
            EnvConfig config = new EnvConfig();
            string[] pathSplit = Path.GetFileName(path).Split("-");
            config.EnvironmentName = pathSplit[0];
            using(ZipArchive archive = ZipFile.OpenRead(path))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    switch (entry.Name)
                    {
                        case "User.csv":
                            using (var stream = entry.Open())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        config.Users = csv.GetRecords<User>().ToList();
                                    }
                                }
                            }
                            break;
                        case "SecurityUserRoleAssociation.csv":
                            using (var stream = entry.Open())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        config.SecurityUserRoles = csv.GetRecords<SecurityUserRole>().ToList();
                                    }
                                }
                            }
                            break;
                        case "SecurityUserRoleOrganization.csv":
                            using (var stream = entry.Open())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        config.SecurityUserRoleOrgs = csv.GetRecords<SecurityUserRoleOrganization>().ToList();
                                    }
                                }
                            }
                            break;
                        case "RoleAccess.csv":
                            using (var stream = entry.Open())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                    {
                                        config.RoleAccessList = csv.GetRecords<RoleAccess>().ToList();
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            return config;
        }

        public SecurityAccessChanges ConvertRoleAccessToSecurityAccess(RoleAccessDetailed srcAccess, RoleAccessDetailed destAccess)
        {
            SecurityAccessChanges sac = new SecurityAccessChanges();

            if (srcAccess == null)
            {
                sac.RoleSystemName = destAccess.RoleSystemName;
                sac.SubRoleSystemName = destAccess.SubRoleSystemName;
                sac.DutySystemName = destAccess.DutySystemName;
                sac.PrivilegeSystemName = destAccess.PrivilegeSystemName;
                sac.SecurableObject = destAccess.SecurableObject;
                sac.SecurableObjectType = destAccess.SecurableType.ToString();
                sac.Read = destAccess.Read.ToString();
                sac.Update = destAccess.Update.ToString();
                sac.Create = destAccess.Create.ToString();
                sac.Delete = destAccess.Delete.ToString();
                sac.Invoke = destAccess.Invoke.ToString();
                sac.Action = "Added";
            }
            else if (destAccess == null)
            {
                sac.RoleSystemName = srcAccess.RoleSystemName;
                sac.SubRoleSystemName = srcAccess.SubRoleSystemName;
                sac.DutySystemName = srcAccess.DutySystemName;
                sac.PrivilegeSystemName = srcAccess.PrivilegeSystemName;
                sac.SecurableObject = srcAccess.SecurableObject;
                sac.SecurableObjectType = srcAccess.SecurableType.ToString();
                sac.Read = srcAccess.Read.ToString();
                sac.Update = srcAccess.Update.ToString();
                sac.Create = srcAccess.Create.ToString();
                sac.Delete = srcAccess.Delete.ToString();
                sac.Invoke = srcAccess.Invoke.ToString();
                sac.Action = "Removed";
            }
            else if (srcAccess != null && destAccess != null)
            {
                sac.RoleSystemName = destAccess.RoleSystemName;
                sac.SubRoleSystemName = destAccess.SubRoleSystemName;
                sac.DutySystemName = destAccess.DutySystemName;
                sac.PrivilegeSystemName = destAccess.PrivilegeSystemName;
                sac.SecurableObject = destAccess.SecurableObject;
                sac.SecurableObjectType = destAccess.SecurableType.ToString();
                sac.Read = srcAccess.Read.ToString() + " -> " + destAccess.Read.ToString();
                sac.Update = srcAccess.Update.ToString() + " -> " + destAccess.Update.ToString();
                sac.Create = srcAccess.Create.ToString() + " -> " + destAccess.Create.ToString();
                sac.Delete = srcAccess.Delete.ToString() + " -> " + destAccess.Delete.ToString();
                sac.Invoke = srcAccess.Invoke.ToString() + " -> " + destAccess.Invoke.ToString();
                sac.Action = "Modified";
            }
            return sac;
        }

#endregion

#region Event Handlers

private void btnSrcBrowse_Click(object sender, EventArgs e)
        {
            ofd_src.Filter = "Zip Files|*.zip";
            ofd_src.Title = "Select a File";
            if (ofd_src.ShowDialog() == DialogResult.OK)
            {
                tb_srcFile.Text = ofd_src.FileName;
            }
        }

        private void btnDestBrowse_Click(object sender, EventArgs e)
        {
            ofd_dest.Filter = "Zip Files|*.zip";
            ofd_dest.Title = "Select a File";
            if (ofd_dest.ShowDialog() == DialogResult.OK)
            {
                tb_destFile.Text = ofd_dest.FileName;
            }
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tb_outputFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void tbSrcFile_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(tb_destFile.Text) && File.Exists(tb_srcFile.Text) && Directory.Exists(tb_outputFolder.Text))
            {
                btn_generate.Enabled = true;
            }
            else
            {
                btn_generate.Enabled = false;
            }
        }

        private void tbDestFile_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(tb_destFile.Text) && File.Exists(tb_srcFile.Text) && Directory.Exists(tb_outputFolder.Text))
            {
                btn_generate.Enabled = true;
            }
            else
            {
                btn_generate.Enabled = false;
            }
        }

        private void tbOutputFile_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(tb_destFile.Text) && File.Exists(tb_srcFile.Text) && Directory.Exists(tb_outputFolder.Text))
            {
                btn_generate.Enabled = true;
            }
            else
            {
                btn_generate.Enabled = false;
            }
        }

        #endregion
    }
}