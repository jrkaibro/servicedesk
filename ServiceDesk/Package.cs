using Artech.Architecture.UI.Framework.Packages;
using Artech.Architecture.UI.Framework.Controls;
using System;
using System.Runtime.InteropServices;
using ServiceDesk.Gateway.Services;

namespace DealerNet.Packages.ServiceDesk
{
	[Guid("d89dfc1e-f12d-420c-9c93-18bfdfc6a3b0")]
	public class Package : AbstractPackageUI
	{
		public override string Name
		{
			get { return "ServiceDesk"; }
		}

        private ServDeskCommit _servDeskCommit;
        
	    public override IToolWindow CreateToolWindow(Guid serviceDeskCommitId)
        {
            if (serviceDeskCommitId.Equals(ServDeskCommit.Guid))
            {
                return _servDeskCommit ?? (_servDeskCommit = new ServDeskCommit(new GenexusService()));
            }

            return base.CreateToolWindow(serviceDeskCommitId);
        }

	}
}
