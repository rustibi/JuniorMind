using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elections
{

    [TestClass]
    public class ElectionsTests
    {

        [TestMethod]
        public void ShouldSortAlphabeticallyAListOfCandidates()
        {
            Candidate[] list = new Candidate[]
            {
                    new Candidate("Iliescu", 100),
                    new Candidate("Basescu", 80),
                    new Candidate("Constantinescu", 60),
                    new Candidate("Ceausescu", 40)
             };

            Candidate[] result = new Candidate[]
            {
                new Candidate("Basescu", 80),
                new Candidate("Ceausescu", 40),
                new Candidate("Constantinescu", 60),
                new Candidate("Iliescu", 100)
            };
            var function = SortAlphabetically(list);
            CollectionAssert.AreEqual(result, function);
        }


        [TestMethod]
        public void ShouldAddAllVotesOfACandidateFromAllLists()
        {
            List[] list = new List[]
            {
                new List(new Candidate[]
                {
                    new Candidate("Iliescu", 100),
                    new Candidate("Basescu", 80),
                    new Candidate("Constantinescu", 60),
                    new Candidate("Ceausescu", 40)
                }),
                new List(new Candidate[]
                {
                    new Candidate("Basescu", 120),
                    new Candidate("Iliescu", 100),
                    new Candidate("Ceausescu", 80),
                    new Candidate("Constantinescu", 20)
                }),
                new List(new Candidate[]
                {
                    new Candidate("Ceausescu", 200),
                    new Candidate("Constantinescu", 100),
                    new Candidate("Basescu", 50),
                    new Candidate("Iliescu", 10)
                })
            };

            Candidate[] result = new Candidate[]
            {
                new Candidate("Ceausescu", 320),
                new Candidate("Basescu", 250),
                new Candidate("Iliescu", 210),
                new Candidate("Constantinescu", 180)
            };
            var function = Group(list);
            CollectionAssert.AreEqual(result, function);
        }


        [TestMethod]
        public void ShouldSortByNoOfVotesAListOfCandidates()
        {
            Candidate[] list = new Candidate[]
            {
                new Candidate("Basescu", 250),
                new Candidate("Ceausescu", 320),
                new Candidate("Constantinescu", 180),
                new Candidate("Iliescu", 210),
             };

            Candidate[] result = new Candidate[]
            { 
                new Candidate("Ceausescu", 320),
                new Candidate("Basescu", 250),
                new Candidate("Iliescu", 210),
                new Candidate("Constantinescu", 180)
            };
            var function = SortByVotes(list);
            CollectionAssert.AreEqual(result, function);
        }



        public struct Candidate
        {
            public string name;
            public int votes;
            public Candidate(string name, int votes)
            {
                this.name = name;
                this.votes = votes;
            }
        }


        public struct List
        {
            public Candidate[] candidates;
            public List(Candidate[] candidates)
            {
                this.candidates = candidates;
            }
        }


        public Candidate[] SortByVotes(Candidate[] listToBeSortedByNoOfVotes)
        {
            for (int i = 0; i < listToBeSortedByNoOfVotes.Length; i++)
            {
                for (int j = i + 1; j < listToBeSortedByNoOfVotes.Length; j++)
                {
                    if (listToBeSortedByNoOfVotes[i].votes < listToBeSortedByNoOfVotes[j].votes)
                    {
                        var temp = listToBeSortedByNoOfVotes[i];
                        listToBeSortedByNoOfVotes[i] = listToBeSortedByNoOfVotes[j];
                        listToBeSortedByNoOfVotes[j] = temp;
                    }
                    else
                        continue;
                }
            }
            return listToBeSortedByNoOfVotes;
        }



        public Candidate[] Group (List[] listSortedAlphabetically)
        {
            List[] groupSorted = SortAlphabetically(listSortedAlphabetically);
            Candidate[] groupToAddVotes = groupSorted[0].candidates;

            for (int i = 0; i < groupToAddVotes.Length; i++)
            {
                for (int j = 1; j < groupSorted.Length; j++)
                {
                    groupToAddVotes[i].votes = groupToAddVotes[i].votes + groupSorted[j].candidates[i].votes;
                }
            }
            groupToAddVotes = SortByVotes(groupToAddVotes);
            return groupToAddVotes;
        }



        public List[] SortAlphabetically(List[] list)
        {
            List[] sortCandidatesAlphabetically = new List[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                sortCandidatesAlphabetically[i].candidates = SortAlphabetically(list[i].candidates);
            }

            return sortCandidatesAlphabetically;
        }



        public static Candidate[] SortAlphabetically(Candidate[] listss)
        {
            for (int i = 0; i < listss.Length; i++)
            {
                for (int j = i + 1; j < listss.Length; j++)
                {
                    if (String.Compare(listss[i].name, listss[j].name) > 0)
                    {
                        var temp = listss[i];
                        listss[i] = listss[j];
                        listss[j] = temp;
                    }
                    else
                        continue;
                }
            }
            return listss;
        }
    }
}
