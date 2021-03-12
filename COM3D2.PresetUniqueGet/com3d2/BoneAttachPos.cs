using System;
using System.Collections.Generic;
using System.Text;

namespace COM3D2.PresetUniqueGet
{
	public class BoneAttachPos
	{
		// Token: 0x06001C60 RID: 7264 RVA: 0x000D147E File Offset: 0x000CF87E
		public BoneAttachPos()
		{
		}

		// Token: 0x06001C61 RID: 7265 RVA: 0x000D1491 File Offset: 0x000CF891
		public BoneAttachPos(BoneAttachPos bap)
		{
			this.bEnable = bap.bEnable;
			this.pss = new PosRotScale(bap.pss);
		}

		// Token: 0x04001853 RID: 6227
		public bool bEnable;

		// Token: 0x04001854 RID: 6228
		public PosRotScale pss = new PosRotScale();
	}

}
