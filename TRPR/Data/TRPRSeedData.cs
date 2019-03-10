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
                        ResID = 1,
                        ExpID = 20
                    },
                    new ResearchExpertise
                    {
                        ResID = 2,
                        ExpID = 19
                    },
                    new ResearchExpertise
                    {
                        ResID = 3,
                        ExpID = 18
                    },
                    new ResearchExpertise
                    {
                        ResID = 4,
                        ExpID = 17
                    },
                    new ResearchExpertise
                    {
                        ResID = 5,
                        ExpID = 16
                    },
                    new ResearchExpertise
                    {
                        ResID = 6,
                        ExpID = 15
                    },
                    new ResearchExpertise
                    {
                        ResID = 7,
                        ExpID = 14
                    },
                    new ResearchExpertise
                    {
                        ResID = 8,
                        ExpID = 13
                    },
                    new ResearchExpertise
                    {
                        ResID = 9,
                        ExpID = 12
                    },
                    new ResearchExpertise
                    {
                        ResID = 10,
                        ExpID = 11
                    },
                    new ResearchExpertise
                    {
                        ResID = 9,
                        ExpID = 10
                    },
                    new ResearchExpertise
                    {
                        ResID = 10,
                        ExpID = 9
                    },
                    new ResearchExpertise
                    {
                        ResID = 11,
                        ExpID = 8
                    },
                    new ResearchExpertise
                    {
                        ResID = 12,
                        ExpID = 7
                    },
                    new ResearchExpertise
                    {
                        ResID = 13,
                        ExpID = 6
                    },
                    new ResearchExpertise
                    {
                        ResID = 14,
                        ExpID = 5
                    },
                    new ResearchExpertise
                    {
                        ResID = 15,
                        ExpID = 4
                    },
                    new ResearchExpertise
                    {
                        ResID = 16,
                        ExpID = 3
                    },
                    new ResearchExpertise
                    {
                        ResID = 17,
                        ExpID = 2
                    },
                    new ResearchExpertise
                    {
                        ResID = 18,
                        ExpID = 1
                    },
                    new ResearchExpertise
                    {
                        ResID = 19,
                        ExpID = 1
                    }
                );
                    context.SaveChanges();
                }



                if (!context.ResearchInstitutes.Any())
                {
                    context.ResearchInstitutes.AddRange(
                    new ResearchInstitute
                    {
                        ResID = 1,
                        InstID = 20
                    },
                    new ResearchInstitute
                    {
                        ResID = 2,
                        InstID = 19
                    },
                    new ResearchInstitute
                    {
                        ResID = 3,
                        InstID = 18
                    },
                    new ResearchInstitute
                    {
                        ResID = 4,
                        InstID = 17
                    },
                    new ResearchInstitute
                    {
                        ResID = 5,
                        InstID = 16
                    },
                    new ResearchInstitute
                    {
                        ResID = 6,
                        InstID = 15
                    },
                    new ResearchInstitute
                    {
                        ResID = 7,
                        InstID = 14
                    },
                    new ResearchInstitute
                    {
                        ResID = 8,
                        InstID = 13
                    },
                    new ResearchInstitute
                    {
                        ResID = 9,
                        InstID = 12
                    },
                    new ResearchInstitute
                    {
                        ResID = 10,
                        InstID = 11
                    },
                    new ResearchInstitute
                    {
                        ResID = 9,
                        InstID = 10
                    },
                    new ResearchInstitute
                    {
                        ResID = 10,
                        InstID = 9
                    },
                    new ResearchInstitute
                    {
                        ResID = 11,
                        InstID = 8
                    },
                    new ResearchInstitute
                    {
                        ResID = 12,
                        InstID = 7
                    },
                    new ResearchInstitute
                    {
                        ResID = 13,
                        InstID = 6
                    },
                    new ResearchInstitute
                    {
                        ResID = 14,
                        InstID = 5
                    },
                    new ResearchInstitute
                    {
                        ResID = 15,
                        InstID = 4
                    },
                    new ResearchInstitute
                    {
                        ResID = 16,
                        InstID = 3
                    },
                    new ResearchInstitute
                    {
                        ResID = 17,
                        InstID = 1
                    },
                    new ResearchInstitute
                    {
                        ResID = 18,
                        InstID = 1
                    },
                    new ResearchInstitute
                    {
                        ResID = 19,
                        InstID = 1
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
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation in the nursing home: Reinventing a good thing",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 7,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Mental health and transcending life challenges: The role of therapeutic recreation services",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Opinion",
                        PaperLength = 15,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Reflections on therapeutic recreation and youth: Possibilities for broadening horizons",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 27,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Multicultural Sensitivity: An Innovative Mind-Set in Therapeutic Recreation Practice.",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical case study",
                        PaperLength = 15,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "The therapeutic recreation (TR) profession in Canada: Where are we now and where are we going?",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 22,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Outcome effectiveness of therapeutic recreation camping program for adolescents living with cancer and diabetes",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 9,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Effects of a therapeutic camping program on addiction recovery: The Algonquin Haymarket relapse prevention program",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Opinion",
                        PaperLength = 8,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation camps: an effective intervention for children and young people with chronic illness?",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 4,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation program design",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 19,
                        StatID = 2
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Quality of life and identity: The benefits of a community-based therapeutic recreation and adaptive sports program",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Perspective",
                        PaperLength = 18,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation: A practical approach",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical case study",
                        PaperLength = 7,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation modalities and facilitation techniques: A national study",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 21,
                        StatID = 2
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic massage as a therapeutic recreation facilitation technique",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 24,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Guided imagery as a therapeutic recreation modality to reduce pain and anxiety",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Commentary",
                        PaperLength = 8,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Aquatic therapy: a viable therapeutic recreation intervention.",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical case study",
                        PaperLength = 10,
                        StatID = 1
                    },
                    new PaperInfo
                    {
                        PaperTitle = "The benefits of participation in aquatic activities for people with disabilities.",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 16,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Aquatic therapy in community-based therapeutic recreation: pain management in a case of fibromyalgia",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Clinical trial",
                        PaperLength = 14,
                        StatID = 1
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation treats depression in the elderly",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Perspective",
                        PaperLength = 6,
                        StatID = 3
                    },
                    new PaperInfo
                    {
                        PaperTitle = "Therapeutic recreation practice: A strengths approach",
                        PaperAbstract = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar dolor a leo tempus pellentesque. Phasellus molestie sem mattis ipsum euismod ultrices. In nec ultricies neque, a venenatis mi. Nam cursus molestie justo in convallis. Cras mollis efficitur enim in fermentum. Vestibulum laoreet dictum felis in porttitor. Aenean tristique scelerisque turpis in pharetra. Fusce faucibus nisl sed tristique tempor. Phasellus pretium, velit metus.",
                        PaperType = "Original research",
                        PaperLength = 4,
                        StatID = 3
                    }
                );
                    context.SaveChanges();
                }

                if (!context.ReviewAssigns.Any())
                {
                    context.ReviewAssigns.AddRange(
                    new ReviewAssign
                    {
                        PaperID = 1,
                        ResID = 1,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 1,
                        ResID = 11,
                        RoleID = 5,
                        RecID = 2,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 10,
                        ResID = 7,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 10,
                        ResID = 4,
                        RoleID = 5,
                        RecID = 4,
                        ReRevID = 2
                    },
                    new ReviewAssign
                    {
                        PaperID = 5,
                        ResID = 2,
                        RoleID = 4,
                        RecID = 3,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 5,
                        ResID = 17,
                        RoleID = 5,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 8,
                        ResID = 6,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 8,
                        ResID = 11,
                        RoleID = 5,
                        RecID = 2,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 12,
                        ResID = 20,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 12,
                        ResID = 13,
                        RoleID = 5,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 15,
                        ResID = 12,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 15,
                        ResID = 18,
                        RoleID = 5,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 4,
                        ResID = 12,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 4,
                        ResID = 1,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 20,
                        ResID = 13,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 20,
                        ResID = 8,
                        RoleID = 5,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 16,
                        ResID = 14,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 16,
                        ResID = 4,
                        RoleID = 5,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 7,
                        ResID = 20,
                        RoleID = 4,
                        RecID = 1,
                        ReRevID = 1
                    },
                    new ReviewAssign
                    {
                        PaperID = 7,
                        ResID = 17,
                        RoleID = 5,
                        RecID = 1,
                        ReRevID = 1
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
                        PaperID = 1,
                        ResID = 4,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 2,
                        ResID = 7,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 3,
                        ResID = 9,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 4,
                        ResID = 20,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 5,
                        ResID = 19,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 5,
                        ResID = 1,
                        AuthPapLevel = "Co-Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 6,
                        ResID = 2,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 7,
                        ResID = 1,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 8,
                        ResID = 15,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 8,
                        ResID = 7,
                        AuthPapLevel = "Co-Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 9,
                        ResID = 10,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 10,
                        ResID = 11,
                        AuthPapLevel = "Author"

                    },
                    new AuthoredPaper
                    {
                        PaperID = 12,
                        ResID = 2,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 13,
                        ResID = 15,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 14,
                        ResID = 5,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 15,
                        ResID = 9,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 11,
                        ResID = 3,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 11,
                        ResID = 7,
                        AuthPapLevel = "Co-Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 11,
                        ResID = 8,
                        AuthPapLevel = "Co-Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 18,
                        ResID = 7,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 19,
                        ResID = 12,
                        AuthPapLevel = "Author" 
                    },
                    new AuthoredPaper
                    {
                        PaperID = 20,
                        ResID = 4,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 16,
                        ResID = 3,
                        AuthPapLevel = "Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 17,
                        ResID = 4,
                        AuthPapLevel = "Co-Author"
                    },
                    new AuthoredPaper
                    {
                        PaperID = 17,
                        ResID = 1,
                        AuthPapLevel = "Author"
                    }
                );
                    context.SaveChanges();
                }
                

                //if (!context.ReviewFiles.Any())
                //{
                //    context.ReviewFiles.AddRange(
                //    new ReviewFile
                //    {
                //        RevID = 1,
                //        FileID = 17
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 2,
                //        FileID = 14
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 2,
                //        FileID = 2
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 1,
                //        FileID = 4
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 2,
                //        FileID = 5
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 2,
                //        FileID = 7
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 2,
                //        FileID = 8
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 1,
                //        FileID = 20
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 1,
                //        FileID = 11
                //    },
                //    new ReviewFile
                //    {
                //        RevID = 1,
                //        FileID = 12
                //    }
                //);
                //    context.SaveChanges();
                //}


                //if (!context.PaperFiles.Any())
                //{
                //    context.PaperFiles.AddRange(
                //new PaperFile
                //{
                //    PaperID = 1,
                //    FileID = 19
                //},
                //new PaperFile
                //{
                //    PaperID = 2,
                //    FileID = 18
                //},
                //new PaperFile
                //{
                //    PaperID = 3,
                //    FileID = 16
                //},
                //new PaperFile
                //{
                //    PaperID = 4,
                //    FileID = 15
                //},
                //new PaperFile
                //{
                //    PaperID = 5,
                //    FileID = 13
                //},
                //new PaperFile
                //{
                //    PaperID = 6,
                //    FileID = 10
                //},
                //new PaperFile
                //{
                //    PaperID = 7,
                //    FileID = 9
                //},
                //new PaperFile
                //{
                //    PaperID = 8,
                //    FileID = 6
                //},
                //new PaperFile
                //{
                //    PaperID = 9,
                //    FileID = 3
                //},
                //new PaperFile
                //{
                //    PaperID = 10,
                //    FileID = 1
                //}
                //);
                //    context.SaveChanges();
                //}

                if (!context.PaperKeywords.Any())
                {
                    context.PaperKeywords.AddRange(
                    new PaperKeyword
                    {
                        PaperID = 1,
                        KeyID = 1
                    },
                    new PaperKeyword
                    {
                        PaperID = 1,
                        KeyID = 2
                    },
                    new PaperKeyword
                    {
                        PaperID = 1,
                        KeyID = 3
                    },
                    new PaperKeyword
                    {
                        PaperID = 2,
                        KeyID = 1
                    },
                    new PaperKeyword
                    {
                        PaperID = 2,
                        KeyID = 3
                    },
                    new PaperKeyword
                    {
                        PaperID = 2,
                        KeyID = 7
                    },
                    new PaperKeyword
                    {
                        PaperID = 3,
                        KeyID = 5
                    },
                    new PaperKeyword
                    {   
                        PaperID = 3,
                        KeyID = 7
                    },
                    new PaperKeyword
                    {   
                        PaperID = 3,
                        KeyID = 9
                    },
                    new PaperKeyword
                    {
                        PaperID = 4,
                        KeyID = 8
                    },
                    new PaperKeyword
                    {
                        PaperID = 4,
                        KeyID = 2
                    },
                    new PaperKeyword
                    {
                        PaperID = 4,
                        KeyID = 19
                    },
                    new PaperKeyword
                    {
                        PaperID = 1,
                        KeyID = 1
                    },
                    new PaperKeyword
                    {
                        PaperID = 5,
                        KeyID = 1
                    },
                    new PaperKeyword
                    {
                        PaperID = 5,
                        KeyID = 11
                    },
                    new PaperKeyword
                    {
                        PaperID = 5,
                        KeyID = 19
                    },
                    new PaperKeyword
                   {
                        PaperID = 6,
                        KeyID = 14
                    },
                    new PaperKeyword
                    {
                        PaperID = 6,
                        KeyID = 2
                    },
                    new PaperKeyword
                    {
                        PaperID = 6,
                        KeyID = 1
                    },
                    new PaperKeyword
                   {
                        PaperID = 7,
                        KeyID = 18
                    },
                    new PaperKeyword
                   {
                        PaperID = 7,
                        KeyID = 7
                    },
                    new PaperKeyword
                    {
                        PaperID = 7,
                        KeyID = 2
                    },
                    new PaperKeyword
                    {
                        PaperID = 8,
                        KeyID = 4
                    },
                    new PaperKeyword
                    {
                        PaperID = 8,
                        KeyID = 8
                    },
                    new PaperKeyword
                    {
                        PaperID = 8,
                        KeyID = 11
                    },
                    new PaperKeyword
                    {
                        PaperID = 9,
                        KeyID = 12
                    },
                    new PaperKeyword
                    {
                        PaperID = 9,
                        KeyID = 4
                    },
                    new PaperKeyword
                    {
                        PaperID = 9,
                        KeyID = 6
                    },
                    new PaperKeyword
                    {
                        PaperID = 10,
                        KeyID = 1
                    },
                    new PaperKeyword
                    {
                        PaperID = 10,
                        KeyID = 14
                    },
                    new PaperKeyword
                    {
                        PaperID = 10,
                        KeyID = 12
                    }
                );
                    context.SaveChanges();
                }
            }
        }
    }
}

