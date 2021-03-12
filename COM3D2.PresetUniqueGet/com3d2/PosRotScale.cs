using System;
using System.Collections.Generic;

using System.Text;

namespace COM3D2.PresetUniqueGet
{
	public class PosRotScale
	{
		// Token: 0x06005396 RID: 21398 RVA: 0x0028E630 File Offset: 0x0028CA30
		public PosRotScale()
		{
		}

		// Token: 0x06005397 RID: 21399 RVA: 0x0028E638 File Offset: 0x0028CA38
		public PosRotScale(PosRotScale prs)
		{
			this.position = prs.position;
			this.scale = prs.scale;
			this.rotation = prs.rotation;
		}

		// Token: 0x04004BD7 RID: 19415
		public Vector3 position;

		// Token: 0x04004BD8 RID: 19416
		public Vector3 scale;

		// Token: 0x04004BD9 RID: 19417
		public Quaternion rotation;
	}

}
