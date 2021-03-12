using System;
using System.Collections.Generic;
using System.Text;

namespace COM3D2.PresetUniqueGet
{
	public class VtxAttachPos
	{
		// Token: 0x06001C62 RID: 7266 RVA: 0x000D14C1 File Offset: 0x000CF8C1
		public VtxAttachPos()
		{
		}

		// Token: 0x06001C63 RID: 7267 RVA: 0x000D14D4 File Offset: 0x000CF8D4
		public VtxAttachPos(VtxAttachPos vap)
		{
			this.bEnable = vap.bEnable;
			this.vtxcount = vap.vtxcount;
			this.vidx = vap.vidx;
			this.prs = new PosRotScale(vap.prs);
		}

		// Token: 0x04001855 RID: 6229
		public bool bEnable;

		// Token: 0x04001856 RID: 6230
		public int vtxcount;

		// Token: 0x04001857 RID: 6231
		public int vidx;

		// Token: 0x04001858 RID: 6232
		public PosRotScale prs = new PosRotScale();
	}

}
