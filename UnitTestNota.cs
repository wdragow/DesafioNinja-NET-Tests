using Employer_Project.Models;
using Employer_Project.Repository;
using NUnit.Framework;
using System;

namespace NUnitTestProject3
{
    public class TestsNota
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateNotaOK()
        {
            var notaRepository = new NotaRepository();
            var alunoRepository = new AlunoRepository();
            var materiaRepository = new MateriaRepository();

            var alunoModel = new AlunoModel()
            {
                AlunoCPF = 99689899082,
                AlunoNome = "Logan",
                AlunoSobrenome = "Da Silva",
                AlunoCurso = "Geografia",
                AlunoNascimento = Convert.ToDateTime("10/02/1998"),
            };
            alunoRepository.CreateAluno(alunoModel);
            alunoRepository.VerificaCPFAluno(alunoModel.AlunoCPF.ToString(), out int? idAluno);

            var materiaModel = new MateriaModel()
            {
                MateriaDesc = "Matemática",
                MateriaDataCad = DateTime.Parse("10/10/2000"),
                materiaSitacao = "A"
            };
            materiaRepository.CreateMateria(materiaModel);
            materiaRepository.VerificaMateriaCadastrada(materiaModel.MateriaDesc, out int? idMateria);

            var notaModel = new NotasAlunoModel()
            {
                AlunoID = Convert.ToInt32(idAluno),
                MateriaID = Convert.ToInt32(idMateria),
                notaMateria = 100
            };

            Assert.AreEqual(notaRepository.SalvaNotaMateriaAluno(notaModel), true);

            notaRepository.DeletaNotaMateriaAluno(notaModel);
            alunoRepository.DeleteAluno(alunoModel);
            materiaRepository.DeleteMateria(materiaModel);
        }


        [Test]
        public void TestDeleteNotaOK()
        {
            var notaRepository = new NotaRepository();
            var alunoRepository = new AlunoRepository();
            var materiaRepository = new MateriaRepository();

            var alunoModel = new AlunoModel()
            {
                AlunoCPF = 99689899082,
                AlunoNome = "Logan",
                AlunoSobrenome = "Da Silva",
                AlunoCurso = "Geografia",
                AlunoNascimento = Convert.ToDateTime("10/02/1998"),
            };
            alunoRepository.CreateAluno(alunoModel);
            alunoRepository.VerificaCPFAluno(alunoModel.AlunoCPF.ToString(), out int? idAluno);

            var materiaModel = new MateriaModel()
            {
                MateriaDesc = "Matemática",
                MateriaDataCad = DateTime.Parse("10/10/2000"),
                materiaSitacao = "A"
            };
            materiaRepository.CreateMateria(materiaModel);
            materiaRepository.VerificaMateriaCadastrada(materiaModel.MateriaDesc, out int? idMateria);

            var notaModel = new NotasAlunoModel()
            {
                AlunoID = Convert.ToInt32(idAluno),
                MateriaID = Convert.ToInt32(idMateria),
                notaMateria = 100
            };

            notaRepository.SalvaNotaMateriaAluno(notaModel);

            Assert.AreEqual(notaRepository.DeletaNotaMateriaAluno(notaModel), true);

            notaRepository.DeletaNotaMateriaAluno(notaModel);
            alunoRepository.DeleteAluno(alunoModel);
            materiaRepository.DeleteMateria(materiaModel);
        }

    }
}