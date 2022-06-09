using System;
using System.Collections.Generic;
using Artech.Architecture.Common.Objects;
using Artech.Architecture.Common.Services.TeamDev;

namespace ServiceDesk.Gateway.Interfaces
{
    public interface IGenexusService
    {
        string BuscarDemandaCommit(string nomeUsuario, int codDemanda = 0, int skip = 0);
        string BuscarDemandaUpdate(string codDemanda);
        Boolean EnviarSolucaoObjetos(string codDemanda, string comentario, string solucao);
        string GetLinkGenexusServer();
        IEnumerable<KBObjectHistory> GetListaObjetosModificados();
        string GetUsuario();
        string GetVersaoKb();
        Boolean RealizarCommit(Object comentario, List<KBObjectHistory> objetosModificados);
        ITeamDevClientUpdate BuscarObjetosComitados();
        Boolean RealizarUpdate(ITeamDevClientUpdate task, List<TeamDevUpdateItem> items);
    }
}
