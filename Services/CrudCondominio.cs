using System.Text.Json;
using Trabalho1.Models;

namespace Trabalho1.Services;

public class CrudCondominio: ICrud<Condominio>
{
    public IEnumerable<Condominio> Read()
    {
        List<Condominio> lista = new List<Condominio>();
        string linha;
        
        try
        {
            StreamReader sr = new StreamReader("BancoDeDados/Condominio.txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                Condominio model = JsonSerializer.Deserialize<Condominio>(linha);
                lista.Add(model);
                linha = sr.ReadLine();
            }
            sr.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        
        return lista;
    }

    public void Create(Condominio model)
    {
        try
        {
            StreamWriter sw = new StreamWriter("BancoDeDados/Condominio.txt", true);
            sw.WriteLine(JsonSerializer.Serialize(model));
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public void Update(Condominio model)
    {
        List<Condominio> lista = Read().ToList();
        Condominio condominioParaAtualizar = lista.Find(x => x.Id == model.Id);

        if (condominioParaAtualizar != null)
        {
            condominioParaAtualizar.NomeEmpresa = model.NomeEmpresa;
            condominioParaAtualizar.Administradora = model.Administradora;
            condominioParaAtualizar.Cnpj = model.Cnpj;
            
            StreamWriter sw = new StreamWriter("BancoDeDados/Condominio.txt");
            foreach (var condominio in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(condominio));
            }
            
            sw.Close();
            AtualizarNasUnidades(model);
        }
        else
        {
            Console.WriteLine("Condomínio não encontrado");
        }
    }

    public void Delete(int id)
    {
        List<Condominio> lista = Read().ToList();
        
        Condominio condominioParaRemover = lista.Find(x => x.Id == id);

        if (condominioParaRemover != null)
        {
            DeletarNasUnidades(condominioParaRemover);
            lista.Remove(condominioParaRemover);
            StreamWriter sw = new StreamWriter("BancoDeDados/Condominio.txt");
            foreach (var condominio in lista)
            {
                sw.WriteLine(JsonSerializer.Serialize(condominio));
            }
            
            sw.Close();
        }
        else
        {
            Console.WriteLine("Condomínio não encontrado");
        }
    }
    
    private void AtualizarNasUnidades(Condominio model)
    {
        CrudUnidade<UnidadeComercial> crudUnidadeComercial = new CrudUnidade<UnidadeComercial>();
        CrudUnidade<UnidadeResidencial> crudUnidadeResidencial = new CrudUnidade<UnidadeResidencial>();

        List<UnidadeComercial> unidadesComerciais = crudUnidadeComercial.Read().ToList();
        List<UnidadeResidencial> unidadesResidenciais = crudUnidadeResidencial.Read().ToList();

        foreach (var unidadeComercial in unidadesComerciais)
        {
            if (unidadeComercial.Condominio.Id == model.Id)
            {
                unidadeComercial.Condominio.NomeEmpresa = model.NomeEmpresa;
                unidadeComercial.Condominio.Administradora = model.Administradora;
                unidadeComercial.Condominio.Cnpj = model.Cnpj;
                
                crudUnidadeComercial.Update(unidadeComercial);
            }
        }

        foreach (var unidadeResidencial in unidadesResidenciais)
        {
            if (unidadeResidencial.Condominio.Id == model.Id)
            {
                unidadeResidencial.Condominio.NomeEmpresa = model.NomeEmpresa;
                unidadeResidencial.Condominio.Administradora = model.Administradora;
                unidadeResidencial.Condominio.Cnpj = model.Cnpj;
                
                crudUnidadeResidencial.Update(unidadeResidencial);
            }
        }
    }

    private void DeletarNasUnidades(Condominio model)
    {
        CrudUnidade<UnidadeComercial> crudUnidadeComercial = new CrudUnidade<UnidadeComercial>();
        CrudUnidade<UnidadeResidencial> crudUnidadeResidencial = new CrudUnidade<UnidadeResidencial>();

        List<UnidadeComercial> unidadesComerciais = crudUnidadeComercial.Read().ToList();
        List<UnidadeResidencial> unidadesResidenciais = crudUnidadeResidencial.Read().ToList();

        foreach (var unidadeComercial in unidadesComerciais)
        {
            if (unidadeComercial.Condominio.Id == model.Id)
            {
                unidadeComercial.Condominio = null;

                crudUnidadeComercial.Update(unidadeComercial);
            }
        }
        
        foreach (var unidadeResidencial in unidadesResidenciais)
        {
            if (unidadeResidencial.Condominio.Id == model.Id)
            {
                unidadeResidencial.Condominio = null;

                crudUnidadeResidencial.Update(unidadeResidencial);
            }
        }
    }
}