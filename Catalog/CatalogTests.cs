using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void ShouldOrderStudentsAlphabetically()
        {
            Student[] students = new Student[]
            {
                new Student("Paul", new Material[]
                {
                    new Material("Math", new int[] { 10, 8}),
                    new Material("English", new int[] { 8, 8}),
                    new Material("French", new int[] { 6, 8}),
                    new Material("History", new int[] { 4, 8}),
                    new Material("Spanish", new int[] { 10, 8, 10}),
                    new Material("Geography", new int[] { 10, 10, 8, 10}),
                    new Material("Romanian", new int[] { 6, 6}),
                    new Material("Economy", new int[] { 5, 7, 7}),
                    new Material("Sports", new int[] { 10, 10, 10}),
                    new Material("Biology", new int[] { 5, 7, 9}),
                    new Material("Info", new int[] { 8, 10, 9}),
                    new Material("Philosophy", new int[] { 8, 8, 8})
                }),
                new Student("Raul", new Material[]
                {
                    new Material("Math", new int[] { 10, 8}),
                    new Material("English", new int[] { 8, 8}),
                    new Material("French", new int[] { 6, 8}),
                    new Material("History", new int[] { 4, 8}),
                    new Material("Spanish", new int[] { 10, 8, 10}),
                    new Material("Geography", new int[] { 10, 10, 8, 10}),
                    new Material("Romanian", new int[] { 6, 6}),
                    new Material("Economy", new int[] { 5, 7, 7}),
                    new Material("Sports", new int[] { 10, 10, 10}),
                    new Material("Biology", new int[] { 5, 7, 9}),
                    new Material("Info", new int[] { 8, 10, 9}),
                    new Material("Philosophy", new int[] { 8, 8, 8})
                }),
                new Student("Alin", new Material[]
                {
                    new Material("Math", new int[] { 10, 8}),
                    new Material("English", new int[] { 8, 8}),
                    new Material("French", new int[] { 6, 8}),
                    new Material("History", new int[] { 4, 8}),
                    new Material("Spanish", new int[] { 10, 8, 10}),
                    new Material("Geography", new int[] { 10, 10, 8, 10}),
                    new Material("Romanian", new int[] { 6, 6}),
                    new Material("Economy", new int[] { 5, 7, 7}),
                    new Material("Sports", new int[] { 10, 10, 10}),
                    new Material("Biology", new int[] { 5, 7, 9}),
                    new Material("Info", new int[] { 8, 10, 9}),
                    new Material("Philosophy", new int[] { 8, 8, 8})
                })
            };

            var result = new Student[]
            {
                new Student("Alin", new Material[]
                {
                    new Material("Math", new int[] { 10, 8}),
                    new Material("English", new int[] { 8, 8}),
                    new Material("French", new int[] { 6, 8}),
                    new Material("History", new int[] { 4, 8}),
                    new Material("Spanish", new int[] { 10, 8, 10}),
                    new Material("Geography", new int[] { 10, 10, 8, 10}),
                    new Material("Romanian", new int[] { 6, 6}),
                    new Material("Economy", new int[] { 5, 7, 7}),
                    new Material("Sports", new int[] { 10, 10, 10}),
                    new Material("Biology", new int[] { 5, 7, 9}),
                    new Material("Info", new int[] { 8, 10, 9}),
                    new Material("Philosophy", new int[] { 8, 8, 8})
                }),
                new Student("Paul", new Material[]
                {
                    new Material("Math", new int[] { 10, 8}),
                    new Material("English", new int[] { 8, 8}),
                    new Material("French", new int[] { 6, 8}),
                    new Material("History", new int[] { 4, 8}),
                    new Material("Spanish", new int[] { 10, 8, 10}),
                    new Material("Geography", new int[] { 10, 10, 8, 10}),
                    new Material("Romanian", new int[] { 6, 6}),
                    new Material("Economy", new int[] { 5, 7, 7}),
                    new Material("Sports", new int[] { 10, 10, 10}),
                    new Material("Biology", new int[] { 5, 7, 9}),
                    new Material("Info", new int[] { 8, 10, 9}),
                    new Material("Philosophy", new int[] { 8, 8, 8})
                }),
                new Student("Raul", new Material[]
                {
                    new Material("Math", new int[] { 10, 8}),
                    new Material("English", new int[] { 8, 8}),
                    new Material("French", new int[] { 6, 8}),
                    new Material("History", new int[] { 4, 8}),
                    new Material("Spanish", new int[] { 10, 8, 10}),
                    new Material("Geography", new int[] { 10, 10, 8, 10}),
                    new Material("Romanian", new int[] { 6, 6}),
                    new Material("Economy", new int[] { 5, 7, 7}),
                    new Material("Sports", new int[] { 10, 10, 10}),
                    new Material("Biology", new int[] { 5, 7, 9}),
                    new Material("Info", new int[] { 8, 10, 9}),
                    new Material("Philosophy", new int[] { 8, 8, 8})
                })  
            };
            var function = SortAlphabetically(students);
            CollectionAssert.AreEqual(result, function);
        }


        public Student[] SortAlphabetically(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (String.Compare(students[i].studentName, students[j].studentName) > 0)
                        Change(ref students[i], ref students[j]);
                    else
                        continue;
                }
            }
            return students;
        }


        public void Change (ref Student firstName, ref Student secondName)
        {
            var temp = firstName;
            firstName = secondName;
            secondName = temp;
        }


        public struct Material
        {
            public string materialName;
            public int[] grade;
            public Material (string materialName, int[] grade)
            {
                this.materialName = materialName;
                this.grade = grade;
            }
        }

        public struct Student
        {
            public string studentName;
            public Material[] materials;
            public Student (string studentName, Material[] materials)
            {
                this.studentName = studentName;
                this.materials = materials;
            }
        }




    }
}
