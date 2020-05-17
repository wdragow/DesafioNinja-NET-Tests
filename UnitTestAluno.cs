using Employer_Project.Models;
using Employer_Project.Repository;
using NUnit.Framework;
using System;

namespace NUnitTestProject3
{
    public class TestsAluno
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateAlunoOK()
        {
            var alunoRepository = new AlunoRepository();

            var alunoModel = new AlunoModel()
            {
                AlunoCPF = 99689899082,
                AlunoNome = "Logan",
                AlunoSobrenome = "Da Silva",
                AlunoCurso = "Geografia",
                AlunoNascimento = Convert.ToDateTime("10/02/1998"),
            };

            Assert.AreEqual(alunoRepository.CreateAluno(alunoModel), true);
            alunoRepository.DeleteAluno(alunoModel);
        }

        [Test]
        public void TestCreateAlunoERRO()
        {
            var alunoRepository = new AlunoRepository();

            var alunoModel = new AlunoModel()
            {
                AlunoCPF = 99689899082,
                AlunoNome = "Logan",
                AlunoSobrenome = "Da Silva",
                AlunoCurso = "Geografia",
                AlunoNascimento = Convert.ToDateTime("10/02/1998"),
            };

            alunoRepository.CreateAluno(alunoModel);

            var aluno2Model = new AlunoModel()
            {
                AlunoCPF = 99689899082,
                AlunoNome = "Logan",
                AlunoSobrenome = "Da Silva",
                AlunoCurso = "Geografia",
                AlunoNascimento = Convert.ToDateTime("10/02/1998"),
            };

            Assert.AreEqual(alunoRepository.CreateAluno(aluno2Model), false);
            alunoRepository.DeleteAluno(alunoModel);
        }


        [Test]
        public void TestDeleteAlunoOK()
        {
            var alunoRepository = new AlunoRepository();


            var alunoModel = new AlunoModel()
            {
                AlunoCPF = 99689899082,
                AlunoNome = "Logan",
                AlunoSobrenome = "Da Silva",
                AlunoCurso = "Geografia",
                AlunoNascimento = Convert.ToDateTime("10/02/1998"),
            };

            alunoRepository.CreateAluno(alunoModel);

            Assert.AreEqual(alunoRepository.DeleteAluno(alunoModel), true);

        }

        [Test]
        public void TestDeleteAlunoERROR()
        {
            var alunoRepository = new AlunoRepository();

            var alunoModel = new AlunoModel()
            {
                AlunoCPF = 2,
                AlunoNome = "Logan",
                AlunoSobrenome = "Da Silva",
                AlunoCurso = "Geografia",
                AlunoNascimento = Convert.ToDateTime("10/02/1998"),
            };

            Assert.AreEqual(alunoRepository.DeleteAluno(alunoModel), false);
        }
    }
}