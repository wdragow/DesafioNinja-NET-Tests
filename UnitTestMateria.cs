using Employer_Project.Models;
using Employer_Project.Repository;
using NUnit.Framework;
using System;

namespace NUnitTestProject3
{
    public class TestsMateria
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateMateriaOK()
        {
            var materiaRepository = new MateriaRepository();

            var materiaModel = new MateriaModel()
            {
                MateriaDesc = "Matemática",
                MateriaDataCad = DateTime.Parse("10/10/2000"),
                materiaSitacao = "A"
            };

            Assert.AreEqual(materiaRepository.CreateMateria(materiaModel), true);
            materiaRepository.DeleteMateria(materiaModel);
        }

        [Test]
        public void TestCreateMateriaERRO()
        {
            var materiaRepository = new MateriaRepository();

            var materiaModel = new MateriaModel()
            {
                MateriaDesc = "Matemática",
                MateriaDataCad = DateTime.Parse("10/10/2000"),
                materiaSitacao = "A"
            };

            materiaRepository.CreateMateria(materiaModel);

            var materia2Model = new MateriaModel()
            {
                MateriaDesc = "Matemática",
                MateriaDataCad = DateTime.Parse("10/10/2000"),
                materiaSitacao = "A"
            };

            Assert.AreEqual(materiaRepository.CreateMateria(materia2Model), false);
            materiaRepository.DeleteMateria(materiaModel);
        }


        [Test]
        public void TestDeleteMateriaOK()
        {
            var materiaRepository = new MateriaRepository();

            var materiaModel = new MateriaModel()
            {
                MateriaDesc = "Matemática",
                MateriaDataCad = DateTime.Parse("10/10/2000"),
                materiaSitacao = "A"
            };

            materiaRepository.CreateMateria(materiaModel);

            Assert.AreEqual(materiaRepository.DeleteMateria(materiaModel), true);
        }

        [Test]
        public void TestDeleteMateriaERROR()
        {
            var materiaRepository = new MateriaRepository();

            var materiaModel = new MateriaModel()
            {
                MateriaDesc = "Matemática",
                MateriaDataCad = DateTime.Parse("10/10/2000"),
                materiaSitacao = "A"
            };

            Assert.AreEqual(materiaRepository.DeleteMateria(materiaModel), false);
        }
    }
}