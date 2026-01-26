using Knowledge.Domain.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Knowledge.Infrastructure.Context
{
    public class ContextSeed
    {
        private static DBContext _dbContext;
        private static IServiceProvider _serviceProvider;

        public static void Seed(DBContext appDbContext, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _dbContext = appDbContext;
            _dbContext.Database.EnsureCreated();
            _serviceProvider = serviceProvider;

            SeedLK_KnowledgeCategories();
            SeedLK_SubKnowledgeCategories();

            bool IsSeedData = configuration.GetSection("IsSeedData").Get<bool>();
            if (IsSeedData)
            { SeedKnowledge(); }
        }

        private static void SeedLK_KnowledgeCategories()
        {
            string LK_KnowledgeCategoriesJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_KnowledgeCategoriesSeedData.json");
            var LK_KnowledgeCategories = JsonConvert.DeserializeObject<List<LKP_KnowledgeCategory>>(LK_KnowledgeCategoriesJson);

            if (LK_KnowledgeCategories != null && LK_KnowledgeCategories.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    if (!_dbContext.KnowledgeCategories.Any())
                    {
                        foreach (var LK_KnowledgeCategory in LK_KnowledgeCategories)
                        {
                            LK_KnowledgeCategory.CreatedOn = DateTime.Now;
                        }

                        _dbContext.KnowledgeCategories.AddRange(LK_KnowledgeCategories);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var existingKnowledgeCategories = _dbContext.KnowledgeCategories.ToList();
                        var newKnowledgeCategories = LK_KnowledgeCategories
                            .Where(nk => !existingKnowledgeCategories.Any(ek => ek.NameEn == nk.NameEn))
                            .ToList();

                        if (newKnowledgeCategories.Any())
                        {
                            foreach (var KnowledgeCategory in newKnowledgeCategories)
                            {
                                KnowledgeCategory.CreatedOn = DateTime.Now;
                            }

                            _dbContext.KnowledgeCategories.AddRange(newKnowledgeCategories);
                            _dbContext.SaveChanges();
                        }
                    }
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }

        }

        private static void SeedLK_SubKnowledgeCategories()
        {
            string LK_subKnowledgeCategoriesJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_SubKnowledgeCategoriesSeedData.json");
            var LK_subKnowledgeCategories = JsonConvert.DeserializeObject<List<LK_SubKnowledgeCategory>>(LK_subKnowledgeCategoriesJson);

            if (LK_subKnowledgeCategories != null && LK_subKnowledgeCategories.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    if (!_dbContext.KnowledgeCategories.Any())
                    {
                        foreach (var LK_subKnowledgeCategory in LK_subKnowledgeCategories)
                        {
                            LK_subKnowledgeCategory.CreatedOn = DateTime.Now;
                        }

                        _dbContext.SubKnowledgeCategories.AddRange(LK_subKnowledgeCategories);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var existingKnowledgeCategories = _dbContext.SubKnowledgeCategories.ToList();
                        var newSubKnowledgeCategories = LK_subKnowledgeCategories
                            .Where(nk => !existingKnowledgeCategories.Any(ek => ek.NameEn == nk.NameEn))
                            .ToList();

                        if (newSubKnowledgeCategories.Any())
                        {
                            foreach (var KnowledgeCategory in newSubKnowledgeCategories)
                            {
                                KnowledgeCategory.CreatedOn = DateTime.Now;
                            }

                            _dbContext.SubKnowledgeCategories.AddRange(newSubKnowledgeCategories);
                            _dbContext.SaveChanges();
                        }
                    }
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }

        }


        private static void SeedKnowledge()
        {
            string knowledgeSeedJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "KnowledgeSeedData.json");
            var knowledges = JsonConvert.DeserializeObject<List<Knowledge.Domain.Models.Knowledge>>(knowledgeSeedJson);

            if (knowledges != null && knowledges.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    if (!_dbContext.Knowledges.Any())
                    {
                        foreach (var knowledge in knowledges)
                        {
                            knowledge.CreatedOn = DateTime.Now;

                            // SubKnowledges
                            if (knowledge.SubKnowledges != null)
                            {
                                foreach (var sub in knowledge.SubKnowledges)
                                {
                                    sub.CreatedOn = DateTime.Now;

                                    if (sub.ParticipatingParties != null)
                                    {
                                        foreach (var org in sub.ParticipatingParties)
                                        {
                                            org.CreatedOn = DateTime.Now;
                                        }
                                    }

                                   
                                    if (sub.KnowledgeAttachments != null)
                                    {
                                        foreach (var attachment in sub.KnowledgeAttachments)
                                        {
                                            attachment.CreatedOn = DateTime.Now;
                                        }
                                    }

                                    if (sub.KnowledgeFavoirates != null)
                                    {
                                        foreach (var fav in sub.KnowledgeFavoirates)
                                        {
                                            fav.CreatedOn = DateTime.Now;
                                        }
                                    }

                                    if (sub.KnowledgeLikes != null)
                                    {
                                        foreach (var like in sub.KnowledgeLikes)
                                        {
                                            like.CreatedOn = DateTime.Now;
                                        }
                                    }

                                    if (sub.KnowledgeRates != null)
                                    {
                                        foreach (var rate in sub.KnowledgeRates)
                                        {
                                            rate.CreatedOn = DateTime.Now;
                                        }
                                    }
                                }
                            }

                            // Knowledge Orgs
                            if (knowledge.OrgHierarchyIds != null)
                            {
                                foreach (var org in knowledge.OrgHierarchyIds)
                                {
                                    org.CreatedOn = DateTime.Now;
                                }
                            }
                        }

                        _dbContext.Knowledges.AddRange(knowledges);
                        _dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception or log it
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }

    }
}
