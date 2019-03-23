using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRPR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TRPR.Data
{
    public class TRPRSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new TRPRContext(
                serviceProvider.GetRequiredService<DbContextOptions<TRPRContext>>()))
            {

                if (!context.Expertises.Any())
                {
                    context.Expertises.AddRange(
                     new Expertise
                     {
                         ExpName = "Psychiatry"
                     },
                     new Expertise
                     {
                         ExpName = "Gerontoloy"
                     },
                     new Expertise
                     {
                         ExpName = "Adventure Therapy"
                     },
                     new Expertise
                     {
                         ExpName = "Rehabilitation"
                     },
                     new Expertise
                     {
                         ExpName = "Program Design"
                     },
                     new Expertise
                     {
                         ExpName = "Adolescents"
                     },
                     new Expertise
                     {
                         ExpName = "Music Therapy"
                     },
                     new Expertise
                     {
                         ExpName = "Management"
                     },
                     new Expertise
                     {
                         ExpName = "Occupational Therapy"
                     },
                     new Expertise
                     {
                         ExpName = "Clinical Practice"
                     },
                     new Expertise
                     {
                         ExpName = "Psychiatry"
                     },
                     new Expertise
                     {
                         ExpName = "Gerontoloy"
                     },
                     new Expertise
                     {
                         ExpName = "Nursing Homes"
                     },
                     new Expertise
                     {
                         ExpName = "Animal Assisted Therapy"
                     },
                     new Expertise
                     {
                         ExpName = "Dementia"
                     },
                     new Expertise
                     {
                         ExpName = "Depression"
                     },
                     new Expertise
                     {
                         ExpName = "Spinal Cord Injury"
                     },
                     new Expertise
                     {
                         ExpName = "Older Adults"
                     },
                     new Expertise
                     {
                         ExpName = "Fluid Therapy"
                     },
                     new Expertise
                     {
                         ExpName = "Herbal Therapy"
                     }
                );
                    context.SaveChanges();
                }
                if (!context.Institutes.Any())
                {
                    context.Institutes.AddRange(
                    new Institute
                    {
                        InstName = "Doughlas College"
                    },
                    new Institute
                    {
                        InstName = "Brock University"
                    },
                    new Institute
                    {
                        InstName = "Seneca College"
                    },
                    new Institute
                    {
                        InstName = "Candore College"
                    },
                    new Institute
                    {
                        InstName = "Lethbridge College"
                    },
                    new Institute
                    {
                        InstName = "NorQuest College"
                    },
                    new Institute
                    {
                        InstName = "University of Waterloo"
                    },
                    new Institute
                    {
                        InstName = "Mohawk College"
                    },
                    new Institute
                    {
                        InstName = "Georgian College"
                    },
                    new Institute
                    {
                        InstName = "Niagara College"
                    },
                    new Institute
                    {
                       InstName = "McMaster University"
                    },
                    new Institute
                    {
                        InstName = "Memorial University"
                    },
                    new Institute
                    {
                        InstName = "University of British Columbia"
                    },
                    new Institute
                    {
                        InstName = "Univeristy of Toronto"
                    },
                    new Institute
                    {
                        InstName = "McGill University"
                    },
                    new Institute
                    {
                        InstName = "University of Alberta"
                    },
                    new Institute
                    {
                        InstName = "York University"
                    },
                    new Institute
                    {
                        InstName = "Univeristy of Guelph"
                    },
                    new Institute
                    {
                        InstName = "Queens University"
                    },
                    new Institute
                    {
                        InstName = "Univeristy of Calgary"
                    }
                );
                    context.SaveChanges();
                }

                if (!context.FileTypes.Any())
                {
                    context.FileTypes.AddRange(
                    new FileType
                    {
                        TypeName = "Main Manuscript"
                    },
                    new FileType
                    {
                        TypeName = "Revision"
                    },
                    new FileType
                    {
                        TypeName = "Review"
                    }
                );
                    context.SaveChanges();
                }


                if (!context.Statuses.Any())
                {
                    context.Statuses.AddRange(
                    new Status
                    {
                        StatName = "Accepted"
                    },
                    new Status
                    {
                        StatName = "Rejected"
                    },
                    new Status
                    {
                        StatName = "Awaiting Review"
                    }
                );
                    context.SaveChanges();
                }

                if (!context.Keywords.Any())
                {
                    context.Keywords.AddRange(
                    new Keyword
                    {
                        KeyWord = "Adolescent Development"
                    },
                    new Keyword
                    {
                        KeyWord = "Adolescents"
                    },
                    new Keyword
                    {
                        KeyWord = "Adventure Education"
                    },
                    new Keyword
                    {
                        KeyWord = "At Risk Persons"
                    },
                    new Keyword
                    {
                        KeyWord = "Delinquency"
                    },
                    new Keyword
                    {
                        KeyWord = "Mental Health"
                    },
                    new Keyword
                    {
                        KeyWord = "Program Development"
                    },
                    new Keyword
                    {
                        KeyWord = "Program Evaluation"
                    },
                    new Keyword
                    {
                        KeyWord = "Recovery"
                    },
                    new Keyword
                    {
                        KeyWord = "Physical"
                    },
                    new Keyword
                    {
                        KeyWord = "Gerontoloy"
                    },
                    new Keyword
                    {
                        KeyWord = "Leadership"
                    },
                    new Keyword
                    {
                        KeyWord = "Leisure Theory"
                    },
                    new Keyword
                    {
                        KeyWord = "Motor Reactions"
                    },
                    new Keyword
                    {
                        KeyWord = "Self Concept"
                    },
                    new Keyword
                    {
                        KeyWord = "Disabilities"
                    },
                    new Keyword
                    {
                        KeyWord = "Individualised Education Programs"
                    },
                    new Keyword
                    {
                        KeyWord = "Physical Fitness"
                    },
                    new Keyword
                    {
                        KeyWord = "Laws"
                    },
                    new Keyword
                    {
                        KeyWord = "Hunan Posture"
                    }
                );
                    context.SaveChanges();
                }


                if (!context.Recommends.Any())
                {
                    context.Recommends.AddRange(
                    new Recommend
                    {
                        RecTitle = "Major Revision"
                    },
                    new Recommend
                    {
                        RecTitle = "Minor Revision"
                    },
                    new Recommend
                    {
                        RecTitle = "Accepted"
                    },
                    new Recommend
                    {
                        RecTitle = "Rejected"
                    }
                );
                    context.SaveChanges();
                }

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                    new Role
                    {
                        RoleTitle = "Author"
                    },
                    new Role
                    {
                        RoleTitle = "Associate Editor"
                    },
                    new Role
                    {
                        RoleTitle = "Editor"
                    },
                    new Role
                    {
                        RoleTitle = "Reveiwer 1"
                    },
                    new Role
                    {
                        RoleTitle = "Reviewer 2"
                    }
                );
                    context.SaveChanges();
                }

                if (!context.ReviewAgains.Any())
                {
                    context.ReviewAgains.AddRange(
                    new ReviewAgain
                    {
                        ReSponse = true
                    },
                    new ReviewAgain
                    {
                        ReSponse = false
                    }
                );
                    context.SaveChanges();
                }

                if (!context.Researchers.Any())
                {
                    context.Researchers.AddRange(
                    new Researcher
                    {
                        ResTitle = "Ms",
                        ResFirst = "Alicia",
                        ResLast = "Keys",
                        ResEmail = "akeys@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Mr",
                        ResFirst = "Alexander",
                        ResMiddle = "R",
                        ResLast = "Junior",
                        ResEmail = "arjunior@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Ms",
                        ResFirst = "Hannah",
                        ResMiddle = "Y",
                        ResLast = "Kim",
                        ResEmail = "hanahkim@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Mr",
                        ResFirst = "Karen",
                        ResLast = "Cho",
                        ResEmail = "kcho@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Ms",
                        ResFirst = "Min",
                        ResMiddle = "Jung",
                        ResLast = "Kim",
                        ResEmail = "kmj@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Mr",
                        ResFirst = "Dolan",
                        ResLast = "Grays",
                        ResEmail = "dgrays@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Dr",
                        ResFirst = "Ethan",
                        ResMiddle = "Alex",
                        ResLast = "Greys",
                        ResEmail = "ethangreys@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Ms",
                        ResFirst = "Emma",
                        ResMiddle = "Hec",
                        ResLast = "Cham",
                        ResEmail = "emma@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Mr",
                        ResFirst = "James",
                        ResMiddle = "H",
                        ResLast = "Charles",
                        ResEmail = "james@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Dr",
                        ResFirst = "Alexandra",
                        ResMiddle = "Di",
                        ResLast = "Angelo",
                        ResEmail = "alexandra@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Ms",
                        ResFirst = "Janice",
                        ResLast = "Joplin",
                        ResEmail = "jjpolin@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Mr",
                        ResFirst = "Alex",
                        ResMiddle = "B",
                        ResLast = "Nolan",
                        ResEmail = "abnolan@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Ms",
                        ResFirst = "Hannah",
                        ResLast = "Mack",
                        ResEmail = "hmackm@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Mrs",
                        ResFirst = "Katherine",
                        ResLast = "Cho",
                        ResEmail = "katcho@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Ms",
                        ResFirst = "Kim",
                        ResMiddle = "Na",
                        ResLast = "Eun",
                        ResEmail = "kimnaeun@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Mr",
                        ResFirst = "Jack",
                        ResLast = "Sparrow",
                        ResEmail = "jacksparrow@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Dr",
                        ResFirst = "Emily",
                        ResMiddle = "Sarah",
                        ResLast = "Sargeant",
                        ResEmail = "essargeant@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Ms",
                        ResFirst = "Han",
                        ResLast = "Solo",
                        ResEmail = "hansolo@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Mr",
                        ResFirst = "James",
                        ResMiddle = "K",
                        ResLast = "Charles",
                        ResEmail = "jameskcharles@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    },
                    new Researcher
                    {
                        ResTitle = "Dr",
                        ResFirst = "Sarah",
                        ResMiddle = "M",
                        ResLast = "Dawson",
                        ResEmail = "sarahmdawson@outlook.com",
                        ResBio = "Lorem ipsum dolor sit am consectetur adipiscing elit.Praesent blandit non eros ac suscipit.Ut vitae est aliquam arcu gravida tempus ac a urna.Curabitur dictum,ligula eu molestie pulvina nisi dolor dignissim massa, quis tincidunt urna tellus ut enim.Aenean mattis purus sit amet urna ornare tempus.Pellentesque diam magna,mollis a molestie eget elementum tempus tellus.Quisque nec."
                    }
                );
                    context.SaveChanges();
                }

                if (!context.ResearchExpertises.Any())
                {
                    context.ResearchExpertises.AddRange(
                    new ResearchExpertise
                    {
                        ResearcherID = 1,
                        ExpertiseID = 20
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 2,
                        ExpertiseID = 19
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 3,
                        ExpertiseID = 18
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 4,
                        ExpertiseID = 17
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 5,
                        ExpertiseID = 16
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 6,
                        ExpertiseID = 15
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 7,
                        ExpertiseID = 14
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 8,
                        ExpertiseID = 13
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 9,
                        ExpertiseID = 12
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 10,
                        ExpertiseID = 11
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 9,
                        ExpertiseID = 10
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 10,
                        ExpertiseID = 9
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 11,
                        ExpertiseID = 8
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 12,
                        ExpertiseID = 7
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 13,
                        ExpertiseID = 6
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 14,
                        ExpertiseID = 5
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 15,
                        ExpertiseID = 4
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 16,
                        ExpertiseID = 3
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 17,
                        ExpertiseID = 2
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 18,
                        ExpertiseID = 1
                    },
                    new ResearchExpertise
                    {
                        ResearcherID = 19,
                        ExpertiseID = 1
                    }
                );
                    context.SaveChanges();
                }



                if (!context.ResearchInstitutes.Any())
                {
                    context.ResearchInstitutes.AddRange(
                    new ResearchInstitute
                    {
                        ResearcherID = 1,
                        InstituteID = 20
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 2,
                        InstituteID = 19
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 3,
                        InstituteID = 18
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 4,
                        InstituteID = 17
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 5,
                        InstituteID = 16
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 6,
                        InstituteID = 15
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 7,
                        InstituteID = 14
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 8,
                        InstituteID = 13
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 9,
                        InstituteID = 12
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 10,
                        InstituteID = 11
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 9,
                        InstituteID = 10
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 10,
                        InstituteID = 9
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 11,
                        InstituteID = 8
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 12,
                        InstituteID = 7
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 13,
                        InstituteID = 6
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 14,
                        InstituteID = 5
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 15,
                        InstituteID = 4
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 16,
                        InstituteID = 3
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 17,
                        InstituteID = 1
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 18,
                        InstituteID = 1
                    },
                    new ResearchInstitute
                    {
                        ResearcherID = 19,
                        InstituteID = 1
                    }
                );
                    context.SaveChanges();
                }

                if (!context.PaperInfos.Any())
                {
                    context.PaperInfos.AddRange(
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation: A practical approach",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical case study",
                        PaperLength = 10,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation in the nursing home: Reinventing a good thing",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 7,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Mental health and transcending life challenges: The role of therapeutic recreation services",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Opinion",
                        PaperLength = 15,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Reflections on therapeutic recreation and youth: Possibilities for broadening horizons",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 27,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Multicultural Sensitivity: An Innovative Mind-Set in Therapeutic Recreation Practice.",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical case study",
                        PaperLength = 15,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "The therapeutic recreation (TR) profession in Canada: Where are we now and where are we going?",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 22,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Outcome effectiveness of therapeutic recreation camping program for adolescents living with cancer and diabetes",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 9,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Effects of a therapeutic camping program on addiction recovery: The Algonquin Haymarket relapse prevention program",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Opinion",
                        PaperLength = 8,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation camps: an effective intervention for children and young people with chronic illness?",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 4,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation program design",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 19,
                        StatusID = 2
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Quality of life and identity: The benefits of a community-based therapeutic recreation and adaptive sports program",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Perspective",
                        PaperLength = 18,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation: A practical approach",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical case study",
                        PaperLength = 7,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation modalities and facilitation techniques: A national study",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 21,
                        StatusID = 2
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic massage as a therapeutic recreation facilitation technique",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 24,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Guided imagery as a therapeutic recreation modality to reduce pain and anxiety",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Commentary",
                        PaperLength = 8,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Aquatic therapy: a viable therapeutic recreation intervention.",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical case study",
                        PaperLength = 10,
                        StatusID = 1
                    },
                    new PaperInfo
                    {
                        PaperTitle = "The benefits of participation in aquatic activities for people with disabilities.",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 16,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Aquatic therapy in community-based therapeutic recreation: pain management in a case of fibromyalgia",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 14,
                        StatusID = 1
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation treats depression in the elderly",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Perspective",
                        PaperLength = 6,
                        StatusID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation practice: A strengths approach",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 4,
                        StatusID = 3
                    }
                );
                    context.SaveChanges();
                }

                if (!context.ReviewAssigns.Any())
                {
                    context.ReviewAssigns.AddRange(
                    new ReviewAssign
                    {
                        PaperInfoID = 1,
                        ResearcherID = 1,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 1,
                        ResearcherID = 11,
                        RoleID = 5,
                        RecommendID = 2,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 10,
                        ResearcherID = 7,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 10,
                        ResearcherID = 4,
                        RoleID = 5,
                        RecommendID = 4,
                        ReviewAgainID = 2
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 5,
                        ResearcherID = 2,
                        RoleID = 4,
                        RecommendID = 3,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 5,
                        ResearcherID = 17,
                        RoleID = 5,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 8,
                        ResearcherID = 6,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 8,
                        ResearcherID = 11,
                        RoleID = 5,
                        RecommendID = 2,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 12,
                        ResearcherID = 20,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 12,
                        ResearcherID = 13,
                        RoleID = 5,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 15,
                        ResearcherID = 12,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 15,
                        ResearcherID = 18,
                        RoleID = 5,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 4,
                        ResearcherID = 12,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 4,
                        ResearcherID = 1,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 20,
                        ResearcherID = 13,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 20,
                        ResearcherID = 8,
                        RoleID = 5,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 16,
                        ResearcherID = 14,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 16,
                        ResearcherID = 4,
                        RoleID = 5,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 7,
                        ResearcherID = 20,
                        RoleID = 4,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    },
                    new ReviewAssign
                    {
                        PaperInfoID = 7,
                        ResearcherID = 17,
                        RoleID = 5,
                        RecommendID = 1,
                        ReviewAgainID = 1
                    }
                );
                    context.SaveChanges();
                }

                if (!context.Comments.Any())
                {
                    context.Comments.AddRange(
                    new Comment
                    {
                        RevID = 1,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 12,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 7,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 4,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 3,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 6,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 13,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 17,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 1,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 12,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 1,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 3,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 20,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 15,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 19,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 8,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 2,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 12,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 17,
                        ComAccess = "Editor",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    },
                    new Comment
                    {
                        RevID = 13,
                        ComAccess = "Author",
                        Comtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In imperdiet pellentesque nisl, vel efficitur risus faucibus sed. Fusce ac libero sit amet eros viverra iaculis. Aenean vestibulum, ex nec ullamcorper pharetra, libero arcu tempus ligula, vel faucibus dolor enim nec dui. Vestibulum efficitur ornare porttitor. Phasellus quis eros lacinia lectus porta laoreet vel quis metus. Maecenas pharetra dictum lorem, sed condimentum sem pharetra turpis duis."
                    }
                );
                    context.SaveChanges();
                }

                if (!context.AuthoredPapers.Any())
                {
                    context.AuthoredPapers.AddRange(
                    new AuthoredPaper
                    {
                        PaperInfoID = 1,
                        ResearcherID = 4,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 2,
                        ResearcherID = 7,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 3,
                        ResearcherID = 9,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 4,
                        ResearcherID = 20,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 5,
                        ResearcherID = 19,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 5,
                        ResearcherID = 1,
                        AuthPapLevel = "Co-Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 6,
                        ResearcherID = 2,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 7,
                        ResearcherID = 1,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 8,
                        ResearcherID = 15,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 8,
                        ResearcherID = 7,
                        AuthPapLevel = "Co-Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 9,
                        ResearcherID = 10,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 10,
                        ResearcherID = 11,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 12,
                        ResearcherID = 2,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 13,
                        ResearcherID = 15,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 14,
                        ResearcherID = 5,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 15,
                        ResearcherID = 9,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 11,
                        ResearcherID = 3,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 11,
                        ResearcherID = 7,
                        AuthPapLevel = "Co-Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 11,
                        ResearcherID = 8,
                        AuthPapLevel = "Co-Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 18,
                        ResearcherID = 7,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 19,
                        ResearcherID = 12,
                        AuthPapLevel = "Author" 
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 20,
                        ResearcherID = 4,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 16,
                        ResearcherID = 3,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 17,
                        ResearcherID = 4,
                        AuthPapLevel = "Co-Author"
                    },
                    new AuthoredPaper
                    {
                        PaperInfoID = 17,
                        ResearcherID = 1,
                        AuthPapLevel = "Author"
                    }
                );
                    context.SaveChanges();
                }
                

                if (!context.PaperKeywords.Any())
                {
                    context.PaperKeywords.AddRange(
                    new PaperKeyword
                    {
                        PaperInfoID = 1,
                        KeywordID = 1
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 1,
                        KeywordID = 2
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 1,
                        KeywordID = 3
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 2,
                        KeywordID = 1
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 2,
                        KeywordID = 3
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 2,
                        KeywordID = 7
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 3,
                        KeywordID = 5
                    },
                    new PaperKeyword
                    {   
                        PaperInfoID = 3,
                        KeywordID = 7
                    },
                    new PaperKeyword
                    {   
                        PaperInfoID = 3,
                        KeywordID = 9
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 4,
                        KeywordID = 8
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 4,
                        KeywordID = 2
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 4,
                        KeywordID = 19
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 4,
                        KeywordID = 1
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 5,
                        KeywordID = 1
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 5,
                        KeywordID = 11
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 5,
                        KeywordID = 19
                    },
                    new PaperKeyword
                   {
                        PaperInfoID = 6,
                        KeywordID = 14
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 6,
                        KeywordID = 2
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 6,
                        KeywordID = 1
                    },
                    new PaperKeyword
                   {
                        PaperInfoID = 7,
                        KeywordID = 18
                    },
                    new PaperKeyword
                   {
                        PaperInfoID = 7,
                        KeywordID = 7
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 7,
                        KeywordID = 2
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 8,
                        KeywordID = 4
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 8,
                        KeywordID = 8
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 8,
                        KeywordID = 11
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 9,
                        KeywordID = 12
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 9,
                        KeywordID = 4
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 9,
                        KeywordID = 6
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 10,
                        KeywordID = 1
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 10,
                        KeywordID = 14
                    },
                    new PaperKeyword
                    {
                        PaperInfoID = 10,
                        KeywordID = 12
                    }
                );
                    context.SaveChanges();
                }
            }
        }
    }
}

