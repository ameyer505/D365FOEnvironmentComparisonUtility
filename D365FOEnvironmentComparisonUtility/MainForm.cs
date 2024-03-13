using CsvHelper;
using D365FOEnvironmentComparisonUtility.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Globalization;
using System.IO.Compression;

namespace D365FOEnvironmentComparisonUtility
{
    public partial class MainForm : Form
    {
        ComparisonOverview overview;
        List<ComparisonDetail> details;
        SecurityComparisonDetails securityComparisonDetails;

        public MainForm()
        {
            InitializeComponent();

            overview = new ComparisonOverview();
            details = new List<ComparisonDetail>();
            securityComparisonDetails = new SecurityComparisonDetails();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tb_output.AppendText(DateTime.Now.ToString() + " - Beginning Environment Comparison" + Environment.NewLine);
            tb_output.AppendText(DateTime.Now.ToString() + " - Loading Environment Configs" + Environment.NewLine);
            EnvConfig src = LoadEnvConfig(tb_srcFile.Text);
            EnvConfig dest = LoadEnvConfig(tb_destFile.Text);
            tb_output.AppendText(DateTime.Now.ToString() + " - Environment Configs Loaded Successfully" + Environment.NewLine);

            tb_output.AppendText(DateTime.Now.ToString() + " - Comparing Users" + Environment.NewLine);
            CompareUsers(src.Users, dest.Users);
            tb_output.AppendText(DateTime.Now.ToString() + " - User Comparison Completed" + Environment.NewLine);
            tb_output.AppendText(DateTime.Now.ToString() + " - Comparing User Roles" + Environment.NewLine);
            CompareUserRoles(src.SecurityUserRoles, dest.SecurityUserRoles);
            tb_output.AppendText(DateTime.Now.ToString() + " - User Role Comparison Completed" + Environment.NewLine);
            tb_output.AppendText(DateTime.Now.ToString() + " - Comparing User Role Orgs" + Environment.NewLine);
            CompareUserRoleOrgs(src.SecurityUserRoleOrgs, dest.SecurityUserRoleOrgs);
            tb_output.AppendText(DateTime.Now.ToString() + " - User Role Orgs Comparison Completed" + Environment.NewLine);
            tb_output.AppendText(DateTime.Now.ToString() + " - Comparing Security");
            CompareSecurity(src.RoleAccessList, dest.RoleAccessList);
            tb_output.AppendText(DateTime.Now.ToString() + " - Security Comparison Completed" + Environment.NewLine);
            tb_output.AppendText(DateTime.Now.ToString() + " - Create Output File" + Environment.NewLine);
            CreateOutputFiles(tb_outputFolder.Text);
            tb_output.AppendText(DateTime.Now.ToString() + " - Output File Created" + Environment.NewLine);
            tb_output.AppendText(DateTime.Now.ToString() + " - Environment Comparison Complete" + Environment.NewLine);
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
                        NewObject = JsonConvert.SerializeObject(destUser),
                        NewValue = destUser.UserID + " - " + destUser.UserName
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
                        NewObject = JsonConvert.SerializeObject(destRole),
                        NewValue = destRole.UserId + " - " + destRole.SecurityRoleName + " (" + destRole.SecurityRoleIdentifier + ")"
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
                        NewObject = JsonConvert.SerializeObject(destUserRoleOrg),
                        NewValue = destUserRoleOrg.OrganizationId
                    });
                }
            }
        }

        public void CompareSecurity(IEnumerable<RoleAccess> srcRoleAccess, IEnumerable<RoleAccess> destRoleAccess)
        {

            List<SecurityLayer> srcRoleList = srcRoleAccess.Select(r => new SecurityLayer { Identifier = r.RoleIdentifier, Name = r.RoleName }).DistinctBy(x => new { x.Identifier }).ToList();
            List<SecurityLayer> destRoleList = destRoleAccess.Select(r => new SecurityLayer { Identifier = r.RoleIdentifier, Name = r.RoleName }).DistinctBy(x => new {x.Identifier}).ToList();

            int srcRoleCount = srcRoleList.Count();
            int destRoleCount = destRoleList.Count();
            int count = 1;
            foreach (var srcRole in srcRoleList)
            {
                tb_output.AppendText(DateTime.Now.ToString() + " - Processing role: " + srcRole.Name + " ("+count+"/"+srcRoleCount + ")" + Environment.NewLine);
                //Look for removed roles
                var destRole = destRoleAccess.FirstOrDefault(r => string.Equals(srcRole.Identifier, r.RoleIdentifier, StringComparison.CurrentCultureIgnoreCase));

                if (destRole == null)
                {
                    overview.RemovedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = srcRole.Identifier,
                            ObjectName = srcRole.Name,
                            ObjectType = "Security Role"
                        });

                    var roleAccesses = srcRoleAccess.Where(ra => string.Equals(ra.RoleIdentifier, srcRole.Identifier, StringComparison.CurrentCultureIgnoreCase));
                    foreach (var roleAccess in roleAccesses)
                        securityComparisonDetails.RemovedRoleAccess.Add(ConvertRoleAccessToSecurityAccess(roleAccess, null));
                }
                else
                {

                    //Role exists in both src and dest environments, compare details

                    //Get each role access
                    var srcAccess = srcRoleAccess.Where(ra => string.Equals(ra.RoleIdentifier, srcRole.Identifier, StringComparison.CurrentCultureIgnoreCase));
                    var destAccess = destRoleAccess.Where(ra => string.Equals(ra.RoleIdentifier, srcRole.Identifier, StringComparison.CurrentCultureIgnoreCase));

                    //Convert to hashset for better comparing capabilities
                    HashSet<RoleAccess> srcRoleAccessesHs = new HashSet<RoleAccess>(srcAccess);
                    HashSet<RoleAccess> destRoleAccessesHs = new HashSet<RoleAccess>(destAccess);

                    //Find the differences
                    HashSet<RoleAccess> srcDiffRoleAccesses = new HashSet<RoleAccess>(srcAccess);
                    HashSet<RoleAccess> destDiffRoleAccesses = new HashSet<RoleAccess>(destAccess);
                    srcDiffRoleAccesses.ExceptWith(destAccess);
                    destDiffRoleAccesses.ExceptWith(srcAccess);

                    if (srcDiffRoleAccesses.Any() || destDiffRoleAccesses.Any())
                    {
                        //Roles have been modified

                        overview.ModifiedObjects.Add(
                            new ComparisonOverviewObject
                            {
                                ObjectId = srcRole.Identifier,
                                ObjectName = srcRole.Name,
                                ObjectType = "Security Role"
                            });


                        HashSet<SecurityAccessChanges> modifiedAccess = new HashSet<SecurityAccessChanges>();
                        foreach (var srcDiffRoleAccess in srcDiffRoleAccesses)
                        {
                            //See if source role access exists in the destination role access
                            var foundAccess = destRoleAccessesHs.FirstOrDefault(ra =>
                                                                               string.Equals(ra.RoleIdentifier, srcDiffRoleAccess.RoleIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.SubRoleIdentifer, srcDiffRoleAccess.SubRoleIdentifer, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.DutyIdentifier, srcDiffRoleAccess.DutyIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.PrivilegeIdentifier, srcDiffRoleAccess.PrivilegeIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
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
                                                                               string.Equals(ra.RoleIdentifier, destDiffRoleAccess.RoleIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.SubRoleIdentifer, destDiffRoleAccess.SubRoleIdentifer, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.DutyIdentifier, destDiffRoleAccess.DutyIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                                                                               string.Equals(ra.PrivilegeIdentifier, destDiffRoleAccess.PrivilegeIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
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
                count++;
            }
            //Now look for added roles
            count = 1;
            foreach (var destRole in destRoleList)
            {
                tb_output.AppendText(DateTime.Now.ToString() + " - Processing role: " + destRole.Name + " (" + count + "/" + destRoleCount + ")" + Environment.NewLine);
                var roleFound = srcRoleList.FirstOrDefault(r => string.Equals(r.Identifier, destRole.Identifier, StringComparison.CurrentCultureIgnoreCase));
                if (roleFound == null)
                {
                    overview.AddedObjects.Add(
                        new ComparisonOverviewObject
                        {
                            ObjectId = destRole.Identifier,
                            ObjectName = destRole.Name,
                            ObjectType = "Security Role"
                        });

                    //Now find the added role access
                    var roleAccesses = destRoleAccess.Where(ra => string.Equals(ra.RoleIdentifier, destRole.Identifier, StringComparison.CurrentCultureIgnoreCase));

                    foreach (var roleAccess in roleAccesses)
                        securityComparisonDetails.AddedRoleAccess.Add(ConvertRoleAccessToSecurityAccess(null, roleAccess));
                }
                //No need to compare role access as we have already done that
                count++;
            }
        }

        public void CreateOutputFiles(string outputPath)
        {
            DateTime currTime = DateTime.Now;
            string sourceEnv = Path.GetFileName(tb_srcFile.Text).Split("-")[0];
            string destEnv = Path.GetFileName(tb_destFile.Text).Split('-')[0];
            string fileName = "EnvComp-" + sourceEnv + "-" + destEnv + "-" + currTime.Day+currTime.Month+currTime.Year+".xlsx";

            string filePath = Path.Combine(outputPath, fileName);
            FileInfo fi = new FileInfo(filePath);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage ep = new ExcelPackage(fi))
            {
                ExcelWorksheet wsMetadata = ep.Workbook.Worksheets.Add("Metadata");
                wsMetadata.Cells[1, 1].Value = "Environment Comparison Date Time:";
                wsMetadata.Cells[1, 2].Value = DateTime.Now.ToString();

                wsMetadata.Cells[2, 1].Value = "Source Environment:";
                wsMetadata.Cells[2, 2].Value = sourceEnv;
                wsMetadata.Cells[3, 1].Value = "Destination Environment:";
                wsMetadata.Cells[3, 2].Value = destEnv;

                wsMetadata.Cells[5, 1].Value = "Added Objects:";
                wsMetadata.Cells[5, 2].Value = overview.AddedObjects.Count;
                wsMetadata.Cells[6, 1].Value = "Modified Objects:";
                wsMetadata.Cells[6, 2].Value = overview.ModifiedObjects.Count;
                wsMetadata.Cells[7, 1].Value = "Removed Objects:";
                wsMetadata.Cells[7, 2].Value = overview.RemovedObjects.Count;

                wsMetadata.Cells.AutoFitColumns();

                ExcelWorksheet wsOverview = ep.Workbook.Worksheets.Add("Overview");
                wsOverview.Cells[1, 1].Value = "Object Id";
                wsOverview.Cells[1, 1].Style.Font.Bold = true;
                wsOverview.Cells[1, 2].Value = "Object Name";
                wsOverview.Cells[1, 2].Style.Font.Bold = true;
                wsOverview.Cells[1, 3].Value = "Object Type";
                wsOverview.Cells[1, 3].Style.Font.Bold = true;
                wsOverview.Cells[1, 4].Value = "Action";
                wsOverview.Cells[1, 4].Style.Font.Bold = true;

                int row = 2;
                foreach(var addedObject in overview.AddedObjects)
                {
                    wsOverview.Cells[row, 1].Value = addedObject.ObjectId;
                    wsOverview.Cells[row, 2].Value = addedObject.ObjectName;
                    wsOverview.Cells[row, 3].Value = addedObject.ObjectType;
                    wsOverview.Cells[row, 4].Value = "Added";
                    row++;
                }

                foreach(var modifiedObject in overview.ModifiedObjects)
                {
                    wsOverview.Cells[row, 1].Value = modifiedObject.ObjectId;
                    wsOverview.Cells[row, 2].Value = modifiedObject.ObjectName;
                    wsOverview.Cells[row, 3].Value = modifiedObject.ObjectType;
                    wsOverview.Cells[row, 4].Value = "Modified";
                    row++;
                }

                foreach(var removedObject in overview.RemovedObjects)
                {
                    wsOverview.Cells[row, 1].Value = removedObject.ObjectId;
                    wsOverview.Cells[row, 2].Value = removedObject.ObjectName;
                    wsOverview.Cells[row, 3].Value = removedObject.ObjectType;
                    wsOverview.Cells[row, 4].Value = "Removed";

                    row++;
                }

                wsOverview.Cells.AutoFitColumns();

                ExcelWorksheet wsDetails = ep.Workbook.Worksheets.Add("Details");
                wsDetails.Cells[1, 1].Value = "Object Id";
                wsDetails.Cells[1, 1].Style.Font.Bold = true;
                wsDetails.Cells[1, 2].Value = "Object Name";
                wsDetails.Cells[1, 2].Style.Font.Bold = true;
                wsDetails.Cells[1, 3].Value = "Object Type";
                wsDetails.Cells[1, 3].Style.Font.Bold = true;
                wsDetails.Cells[1, 4].Value = "Action";
                wsDetails.Cells[1, 4].Style.Font.Bold = true;
                wsDetails.Cells[1, 5].Value = "Old Value";
                wsDetails.Cells[1, 5].Style.Font.Bold = true;
                wsDetails.Cells[1, 6].Value = "New Value";
                wsDetails.Cells[1, 6].Style.Font.Bold = true;
                wsDetails.Cells[1, 7].Value = "Old Object";
                wsDetails.Cells[1, 7].Style.Font.Bold = true;
                wsDetails.Cells[1, 8].Value = "New Object";
                wsDetails.Cells[1, 8].Style.Font.Bold = true;

                row = 2;
                foreach(var detail in details)
                {
                    wsDetails.Cells[row, 1].Value = detail.ObjectId;
                    wsDetails.Cells[row, 2].Value = detail.ObjectName;
                    wsDetails.Cells[row, 3].Value = detail.ObjectType;
                    wsDetails.Cells[row, 4].Value = detail.Action;
                    wsDetails.Cells[row, 5].Value = detail.OldValue;
                    wsDetails.Cells[row, 6].Value = detail.NewValue;
                    wsDetails.Cells[row, 7].Value = FormatJSON(detail.OldObject);
                    wsDetails.Cells[row, 8].Value = FormatJSON(detail.NewObject);

                    row++;
                }

                wsDetails.Column(7).Style.WrapText = true;
                wsDetails.Column(8).Style.WrapText = true;

                wsDetails.Cells.AutoFitColumns(50);

                ExcelWorksheet wsAccChanges = ep.Workbook.Worksheets.Add("Security Access Changes");
                wsAccChanges.Cells[1, 1].Value = "Role Name";
                wsAccChanges.Cells[1, 1].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 2].Value = "Role Identifier";
                wsAccChanges.Cells[1, 2].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 3].Value = "SubRole Name";
                wsAccChanges.Cells[1, 3].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 4].Value = "SubRole Identifier";
                wsAccChanges.Cells[1, 4].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 5].Value = "Duty Name";
                wsAccChanges.Cells[1, 5].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 6].Value = "Duty Identifier";
                wsAccChanges.Cells[1, 6].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 7].Value = "Privilege Name";
                wsAccChanges.Cells[1, 7].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 8].Value = "Privilege Identifier";
                wsAccChanges.Cells[1, 8].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 9].Value = "Securable Object";
                wsAccChanges.Cells[1, 9].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 10].Value = "Securable Object Type";
                wsAccChanges.Cells[1, 10].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 11].Value = "Read";
                wsAccChanges.Cells[1, 11].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 12].Value = "Update";
                wsAccChanges.Cells[1, 12].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 13].Value = "Create";
                wsAccChanges.Cells[1, 13].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 14].Value = "Delete";
                wsAccChanges.Cells[1, 14].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 15].Value = "Invoke";
                wsAccChanges.Cells[1, 15].Style.Font.Bold = true;
                wsAccChanges.Cells[1, 16].Value = "Action";
                wsAccChanges.Cells[1, 16].Style.Font.Bold = true;

                row = 2;
                foreach(var addedSecAcc in securityComparisonDetails.AddedRoleAccess)
                {
                    wsAccChanges.Cells[row, 1].Value = addedSecAcc.RoleName;
                    wsAccChanges.Cells[row, 2].Value = addedSecAcc.RoleIdentifier;
                    wsAccChanges.Cells[row, 3].Value = addedSecAcc.SubRoleName;
                    wsAccChanges.Cells[row, 4].Value = addedSecAcc.SubRoleIdentifier;
                    wsAccChanges.Cells[row, 5].Value = addedSecAcc.DutyName;
                    wsAccChanges.Cells[row, 6].Value = addedSecAcc.DutyIdentifier;
                    wsAccChanges.Cells[row, 7].Value = addedSecAcc.PrivilegeName;
                    wsAccChanges.Cells[row, 8].Value = addedSecAcc.PrivilegeIdentifier;
                    wsAccChanges.Cells[row, 9].Value = addedSecAcc.SecurableObject;
                    wsAccChanges.Cells[row, 10].Value = addedSecAcc.SecurableObjectType;
                    wsAccChanges.Cells[row, 11].Value = addedSecAcc.Read;
                    wsAccChanges.Cells[row, 12].Value = addedSecAcc.Update;
                    wsAccChanges.Cells[row, 13].Value = addedSecAcc.Create;
                    wsAccChanges.Cells[row, 14].Value = addedSecAcc.Delete;
                    wsAccChanges.Cells[row, 15].Value = addedSecAcc.Invoke;
                    wsAccChanges.Cells[row, 16].Value = "Added";

                    row++;
                }

                foreach(var modifiedSecAcc in securityComparisonDetails.ModifiedRoleAccess)
                {
                    wsAccChanges.Cells[row, 1].Value = modifiedSecAcc.RoleName;
                    wsAccChanges.Cells[row, 2].Value = modifiedSecAcc.RoleIdentifier;
                    wsAccChanges.Cells[row, 3].Value = modifiedSecAcc.SubRoleName;
                    wsAccChanges.Cells[row, 4].Value = modifiedSecAcc.SubRoleIdentifier;
                    wsAccChanges.Cells[row, 5].Value = modifiedSecAcc.DutyName;
                    wsAccChanges.Cells[row, 6].Value = modifiedSecAcc.DutyIdentifier;
                    wsAccChanges.Cells[row, 7].Value = modifiedSecAcc.PrivilegeName;
                    wsAccChanges.Cells[row, 8].Value = modifiedSecAcc.PrivilegeIdentifier;
                    wsAccChanges.Cells[row, 9].Value = modifiedSecAcc.SecurableObject;
                    wsAccChanges.Cells[row, 10].Value = modifiedSecAcc.SecurableObjectType;
                    wsAccChanges.Cells[row, 11].Value = modifiedSecAcc.Read;
                    wsAccChanges.Cells[row, 12].Value = modifiedSecAcc.Update;
                    wsAccChanges.Cells[row, 13].Value = modifiedSecAcc.Create;
                    wsAccChanges.Cells[row, 14].Value = modifiedSecAcc.Delete;
                    wsAccChanges.Cells[row, 15].Value = modifiedSecAcc.Invoke;
                    wsAccChanges.Cells[row, 16].Value = "Modified";

                    row++;
                }

                foreach(var removedSecAcc in securityComparisonDetails.RemovedRoleAccess)
                {
                    wsAccChanges.Cells[row, 1].Value = removedSecAcc.RoleName;
                    wsAccChanges.Cells[row, 2].Value = removedSecAcc.RoleIdentifier;
                    wsAccChanges.Cells[row, 3].Value = removedSecAcc.SubRoleName;
                    wsAccChanges.Cells[row, 4].Value = removedSecAcc.SubRoleIdentifier;
                    wsAccChanges.Cells[row, 5].Value = removedSecAcc.DutyName;
                    wsAccChanges.Cells[row, 6].Value = removedSecAcc.DutyIdentifier;
                    wsAccChanges.Cells[row, 7].Value = removedSecAcc.PrivilegeName;
                    wsAccChanges.Cells[row, 8].Value = removedSecAcc.PrivilegeIdentifier;
                    wsAccChanges.Cells[row, 9].Value = removedSecAcc.SecurableObject;
                    wsAccChanges.Cells[row, 10].Value = removedSecAcc.SecurableObjectType;
                    wsAccChanges.Cells[row, 11].Value = removedSecAcc.Read;
                    wsAccChanges.Cells[row, 12].Value = removedSecAcc.Update;
                    wsAccChanges.Cells[row, 13].Value = removedSecAcc.Create;
                    wsAccChanges.Cells[row, 14].Value = removedSecAcc.Delete;
                    wsAccChanges.Cells[row, 15].Value = removedSecAcc.Invoke;
                    wsAccChanges.Cells[row, 16].Value = "Removed";

                    row++;
                }

                wsAccChanges.Cells.AutoFitColumns();

                ep.Save();
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

        public SecurityAccessChanges ConvertRoleAccessToSecurityAccess(RoleAccess srcAccess, RoleAccess destAccess)
        {
            SecurityAccessChanges sac = new SecurityAccessChanges();

            if (srcAccess == null)
            {
                sac.RoleIdentifier = destAccess.RoleIdentifier;
                sac.RoleName = destAccess.RoleName;
                sac.SubRoleIdentifier = destAccess.SubRoleIdentifer;
                sac.SubRoleName = destAccess.SubRoleName;
                sac.DutyIdentifier = destAccess.DutyIdentifier;
                sac.DutyName = destAccess.DutyName;
                sac.PrivilegeIdentifier = destAccess.PrivilegeIdentifier;
                sac.PrivilegeName = destAccess.PrivilegeName;
                sac.SecurableObject = destAccess.SecurableObject;
                sac.SecurableObjectType = destAccess.SecurableType;
                sac.Read = destAccess.Read;
                sac.Update = destAccess.Update;
                sac.Create = destAccess.Create;
                sac.Delete = destAccess.Delete;
                sac.Invoke = destAccess.Invoke;
                sac.Action = "Added";
            }
            else if (destAccess == null)
            {
                sac.RoleIdentifier = srcAccess.RoleIdentifier;
                sac.RoleName = srcAccess.RoleName;
                sac.SubRoleIdentifier = srcAccess.SubRoleIdentifer;
                sac.SubRoleName = srcAccess.SubRoleName;
                sac.DutyIdentifier = srcAccess.DutyIdentifier;
                sac.DutyName = srcAccess.DutyName;
                sac.PrivilegeIdentifier = srcAccess.PrivilegeIdentifier;
                sac.PrivilegeName = srcAccess.PrivilegeName;
                sac.SecurableObject = srcAccess.SecurableObject;
                sac.SecurableObjectType = srcAccess.SecurableType;
                sac.Read = srcAccess.Read;
                sac.Update = srcAccess.Update;
                sac.Create = srcAccess.Create;
                sac.Delete = srcAccess.Delete;
                sac.Invoke = srcAccess.Invoke;
                sac.Action = "Removed";
            }
            else if (srcAccess != null && destAccess != null)
            {
                sac.RoleIdentifier = destAccess.RoleIdentifier;
                sac.RoleName = destAccess.RoleName;
                sac.SubRoleIdentifier = destAccess.SubRoleIdentifer;
                sac.SubRoleName = destAccess.SubRoleName;
                sac.DutyIdentifier = destAccess.DutyIdentifier;
                sac.DutyName = destAccess.DutyName;
                sac.PrivilegeIdentifier = destAccess.PrivilegeIdentifier;
                sac.PrivilegeName = destAccess.PrivilegeName;
                sac.SecurableObject = destAccess.SecurableObject;
                sac.SecurableObjectType = destAccess.SecurableType;
                sac.Read = srcAccess.Read + " -> " + destAccess.Read;
                sac.Update = srcAccess.Update + " -> " + destAccess.Update;
                sac.Create = srcAccess.Create + " -> " + destAccess.Create;
                sac.Delete = srcAccess.Delete + " -> " + destAccess.Delete;
                sac.Invoke = srcAccess.Invoke + " -> " + destAccess.Invoke;
                sac.Action = "Modified";
            }
            return sac;
        }

        public string FormatJSON(string json)
        {
            return json.Replace("{\"", "{\n\"").Replace(",\"", ",\n\"").Replace("\"}", "\"\n}");
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