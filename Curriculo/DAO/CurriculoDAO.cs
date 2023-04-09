using N2B1_Curriculo.DAO;
using N2B1_Curriculo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N2B1_Curriculo.DAO
{
    public class CurriculoDAO
    {

        private SqlParameter[] CriaParametros(CurriculoViewModel curriculo)
        {

            SqlParameter[] paramertros = new SqlParameter[26];
            paramertros[0] = new SqlParameter("cpf", curriculo.Cpf);
            paramertros[1] = new SqlParameter("nome", curriculo.Nome);
            paramertros[2] = new SqlParameter("data_nascimento", curriculo.Data_nascimento);
            paramertros[3] = new SqlParameter("endereco", curriculo.Endereco);
            paramertros[4] = new SqlParameter("email", curriculo.Email);
            paramertros[5] = new SqlParameter("pret_salarial", curriculo.Pret_salarial);
            paramertros[6] = new SqlParameter("cargo_pretendido", curriculo.Cargo_pretendido);
            paramertros[7] = new SqlParameter("curso1", curriculo.Curso1);
            paramertros[8] = new SqlParameter("instituicao1", curriculo.Instituicao1);
            paramertros[9] = new SqlParameter("conclusao1", curriculo.Conclusao1);
            paramertros[10] = new SqlParameter("curso2", curriculo.Curso2);
            paramertros[11] = new SqlParameter("instituicao2", curriculo.Instituicao2);
            paramertros[12] = new SqlParameter("conclusao2", curriculo.Conclusao2);
            paramertros[13] = new SqlParameter("curso3", curriculo.Curso3);
            paramertros[14] = new SqlParameter("instituicao3", curriculo.Instituicao3);
            paramertros[15] = new SqlParameter("conclusao3", curriculo.Conclusao3);
            paramertros[16] = new SqlParameter("curso4", curriculo.Curso4);
            paramertros[17] = new SqlParameter("instituicao4", curriculo.Instituicao4);
            paramertros[18] = new SqlParameter("conclusao4", curriculo.Conclusao4);
            paramertros[19] = new SqlParameter("curso5", curriculo.Curso5);
            paramertros[20] = new SqlParameter("instituicao5", curriculo.Instituicao5);
            paramertros[21] = new SqlParameter("conclusao5", curriculo.Conclusao5);
            paramertros[22] = new SqlParameter("empresa1", curriculo.Empresa1);
            paramertros[23] = new SqlParameter("cargo1", curriculo.Cargo1);
            paramertros[24] = new SqlParameter("tempo_exp1", curriculo.Tempo_exp1);
            paramertros[25] = new SqlParameter("empresa2", curriculo.Empresa2);
            paramertros[26] = new SqlParameter("cargo2", curriculo.Cargo2);
            paramertros[27] = new SqlParameter("tempo_exp2", curriculo.Tempo_exp2);
            paramertros[28] = new SqlParameter("empresa3", curriculo.Empresa3);
            paramertros[29] = new SqlParameter("cargo3", curriculo.Cargo3);
            paramertros[30] = new SqlParameter("tempo_exp3", curriculo.Tempo_exp3);
            paramertros[31] = new SqlParameter("idiomas", curriculo.Idiomas);
            paramertros[32] = new SqlParameter("linkedin", curriculo.Linkedin);
            paramertros[33] = new SqlParameter("telefone", curriculo.Telefone);


            return paramertros;
        }



        /// <summary>
        /// Método para inserir um curriculo no BD
        /// </summary>
        /// <param name="curriculo">objeto aluno com todas os atributos preenchidos</param>
        public void Inserir(CurriculoViewModel curriculo)
        {
            string sql =
            "insert into Curriculos(cpf, nome, data_nascimento, endereco, email, " +
            "pret_salarial, cargo_pretendido, curso1, instituicao1, conclusao1, curso2, instituicao2, conclusao2, " +
            "curso3, instituicao3, conclusao3, curso4, instituicao4, conclusao4, curso5, instituicao5, conclusao5, " +
            "empresa1, cargo1, tempo_exp1,empresa2, cargo2, tempo_exp2,empresa3, cargo3, tempo_exp3, " +
            "idiomas, linkedin, telefone)" +
            "values (@cpf , @nome, @data_nascimento, @endereco, @email, " +
            "@pret_salarial, @cargo_pretendido, @curso1, @instituicao1, @conclusao1,  @curso2, @instituicao2, @conclusao2, " +
            "@curso3, @instituicao3, @conclusao3,  @curso4, @instituicao4, @conclusao4,  @curso5, @instituicao5, @conclusao5, " +
            "@empresa1, @cargo1, @tempo_exp1, @empresa2, @cargo2, @tempo_exp2, @empresa3, @cargo3, @tempo_exp3, " +
            "@idiomas, @linkedin, @telefone)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(curriculo));
        }


        public void Alterar(CurriculoViewModel curriculo)
        {
            string sql =
            "UPDATE Curriculos SET cpf=@cpf, nome=@nome, data_nascimento=@data_nascimento, endereco=@endereco, email=@email, " +
            "pret_salarial=@pret_salarial, cargo_pretendido=@cargo_pretendido, curso1=@curso1, instituicao1=@instituicao1, conclusao1=@conclusao1, " +
            "curso2=@curso2, instituicao2=@instituicao2, conclusao2=@conclusao2, " +
            "curso3=@curso3, instituicao3=@instituicao3, conclusao3=@conclusao3, curso4=@curso4, instituicao4=@instituicao4, conclusao4=@conclusao4, " +
            "curso5=@curso5, instituicao5=@instituicao5, conclusao5=@conclusao5, " +
            "empresa1=@empresa1, cargo1=@cargo1, tempo_exp1=@tempo_exp1,empresa2=@empresa2, cargo2=@cargo2, tempo_exp2=@tempo_exp2,empresa3=@empresa3, cargo3=@cargo3, tempo_exp3=@tempo_exp3, " +
            "idiomas=@idiomas, linkedin=@linkedin, telefone=@telefone" +
            "where cpf = @cpf";
            HelperDAO.ExecutaSQL(sql, CriaParametros(curriculo));
        }

        public void Excluir(string cpf)
        {
            string sql = "delete Curriculos where cpf = " + cpf;
            HelperDAO.ExecutaSQL(sql, null);
        }


        public CurriculoViewModel Consulta(string cpf)
        {
            string sql = "select * from Curriculos where cpf =" + cpf;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);

            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontarCurriculo(tabela.Rows[0]);
        }


        private CurriculoViewModel MontarCurriculo(DataRow registro)
        {
            CurriculoViewModel curriculo = new CurriculoViewModel();
            curriculo.Cpf = registro["cpf"].ToString();
            curriculo.Nome = registro["nome"].ToString();
            curriculo.Data_nascimento = Convert.ToDateTime(registro["data_nascimento"]);
            curriculo.Endereco = registro["endereco"].ToString();
            curriculo.Email = registro["email"].ToString();
            curriculo.Pret_salarial = Convert.ToDouble(registro["pret_salarial"]);
            curriculo.Cargo_pretendido = registro["cargo_pretendido"].ToString();
            curriculo.Curso1 = registro["curso1"].ToString();
            curriculo.Instituicao1 = registro["instituicao1"].ToString();
            curriculo.Conclusao1 = registro["conclusao1"].ToString();
            curriculo.Curso2 = registro["curso2"].ToString();
            curriculo.Instituicao2 = registro["instituicao2"].ToString();
            curriculo.Conclusao2 = registro["conclusao2"].ToString();
            curriculo.Curso3 = registro["curso3"].ToString();
            curriculo.Instituicao3 = registro["instituicao3"].ToString();
            curriculo.Conclusao3 = registro["conclusao3"].ToString();
            curriculo.Curso4 = registro["curso4"].ToString();
            curriculo.Instituicao4 = registro["instituicao4"].ToString();
            curriculo.Conclusao4 = registro["conclusao4"].ToString();
            curriculo.Curso5 = registro["curso5"].ToString();
            curriculo.Instituicao5 = registro["instituicao5"].ToString();
            curriculo.Conclusao5 = registro["conclusao5"].ToString();
            curriculo.Empresa1 = registro["empresa1"].ToString();
            curriculo.Cargo1 = registro["cargo1"].ToString();
            curriculo.Tempo_exp1 = registro["tempo_exp1"].ToString();
            curriculo.Empresa2 = registro["empresa2"].ToString();
            curriculo.Cargo2 = registro["cargo2"].ToString();
            curriculo.Tempo_exp2 = registro["tempo_exp2"].ToString();
            curriculo.Empresa3 = registro["empresa3"].ToString();
            curriculo.Cargo3 = registro["cargo3"].ToString();
            curriculo.Tempo_exp3 = registro["tempo_exp3"].ToString();
            curriculo.Idiomas = registro["idiomas"].ToString();
            curriculo.Linkedin = registro["linkedin"].ToString();
            curriculo.Telefone = registro["telefone"].ToString();
          
            return curriculo;
        }

        public List<CurriculoViewModel> Listar()
        {
            List<CurriculoViewModel> lista = new List<CurriculoViewModel>();
            string sql = "select * from Curriculos order by nome";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontarCurriculo(registro));
            return lista;
        }
    }
}

