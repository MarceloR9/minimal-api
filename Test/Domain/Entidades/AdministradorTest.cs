using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorTest
{
    private DbContexto CriarContextoTeste(){
        var options = new DbContextOptionsBuilder<DbContexto>()
        .UseInMemoryDatabase(databaseName: "TestDatabase")
        .Options;

        return new DbContexto(options);
    }

    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "test1@gmail.com";
        adm.Senha = "123456";
        adm.Perfil = "AdmTeste";
        var context = CriarContextoTeste();
        var administradorServico = new AdministradorServico(contexto);

        //Act
        

        //Arrange
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("test1@gmail.com", adm.Email);
        Assert.AreEqual("123456", adm.Senha);
        Assert.AreEqual("AdmTeste", adm.Perfil);
    }
}