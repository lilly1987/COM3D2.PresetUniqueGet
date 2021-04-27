using System;
using System.Collections.Generic;
using System.Text;

namespace COM3D2.PresetUniqueGet
{
	/*
	public enum MPN
	{
		// Token: 0x040017C3 RID: 6083
		null_mpn,
		// Token: 0x040017C4 RID: 6084
		MuneL,
		// Token: 0x040017C5 RID: 6085
		MuneS,
		// Token: 0x040017C6 RID: 6086
		MuneTare,
		// Token: 0x040017C7 RID: 6087
		RegFat,
		// Token: 0x040017C8 RID: 6088
		ArmL,
		// Token: 0x040017C9 RID: 6089
		Hara,
		// Token: 0x040017CA RID: 6090
		RegMeet,
		// Token: 0x040017CB RID: 6091
		KubiScl,
		// Token: 0x040017CC RID: 6092
		UdeScl,
		// Token: 0x040017CD RID: 6093
		EyeScl,
		// Token: 0x040017CE RID: 6094
		EyeSclX,
		// Token: 0x040017CF RID: 6095
		EyeSclY,
		// Token: 0x040017D0 RID: 6096
		EyePosX,
		// Token: 0x040017D1 RID: 6097
		EyePosY,
		// Token: 0x040017D2 RID: 6098
		EyeClose,
		// Token: 0x040017D3 RID: 6099
		EyeBallPosX,
		// Token: 0x040017D4 RID: 6100
		EyeBallPosY,
		// Token: 0x040017D5 RID: 6101
		EyeBallSclX,
		// Token: 0x040017D6 RID: 6102
		EyeBallSclY,
		// Token: 0x040017D7 RID: 6103
		EarNone,
		// Token: 0x040017D8 RID: 6104
		EarElf,
		// Token: 0x040017D9 RID: 6105
		EarRot,
		// Token: 0x040017DA RID: 6106
		EarScl,
		// Token: 0x040017DB RID: 6107
		NosePos,
		// Token: 0x040017DC RID: 6108
		NoseScl,
		// Token: 0x040017DD RID: 6109
		FaceShape,
		// Token: 0x040017DE RID: 6110
		FaceShapeSlim,
		// Token: 0x040017DF RID: 6111
		MayuShapeIn,
		// Token: 0x040017E0 RID: 6112
		MayuShapeOut,
		// Token: 0x040017E1 RID: 6113
		MayuX,
		// Token: 0x040017E2 RID: 6114
		MayuY,
		// Token: 0x040017E3 RID: 6115
		MayuRot,
		// Token: 0x040017E4 RID: 6116
		HeadX,
		// Token: 0x040017E5 RID: 6117
		HeadY,
		// Token: 0x040017E6 RID: 6118
		DouPer,
		// Token: 0x040017E7 RID: 6119
		sintyou,
		// Token: 0x040017E8 RID: 6120
		koshi,
		// Token: 0x040017E9 RID: 6121
		kata,
		// Token: 0x040017EA RID: 6122
		west,
		// Token: 0x040017EB RID: 6123
		MuneUpDown,
		// Token: 0x040017EC RID: 6124
		MuneYori,
		// Token: 0x040017ED RID: 6125
		MuneYawaraka,
		// Token: 0x040017EE RID: 6126
		MayuThick,
		// Token: 0x040017EF RID: 6127
		MayuLong,
		// Token: 0x040017F0 RID: 6128
		Yorime,
		// Token: 0x040017F1 RID: 6129
		MabutaUpIn,
		// Token: 0x040017F2 RID: 6130
		MabutaUpIn2,
		// Token: 0x040017F3 RID: 6131
		MabutaUpMiddle,
		// Token: 0x040017F4 RID: 6132
		MabutaUpOut,
		// Token: 0x040017F5 RID: 6133
		MabutaUpOut2,
		// Token: 0x040017F6 RID: 6134
		MabutaLowIn,
		// Token: 0x040017F7 RID: 6135
		MabutaLowUpMiddle,
		// Token: 0x040017F8 RID: 6136
		MabutaLowUpOut,
		// Token: 0x040017F9 RID: 6137
		body,
		// Token: 0x040017FA RID: 6138
		moza,
		// Token: 0x040017FB RID: 6139
		head,
		// Token: 0x040017FC RID: 6140
		hairf,
		// Token: 0x040017FD RID: 6141
		hairr,
		// Token: 0x040017FE RID: 6142
		hairt,
		// Token: 0x040017FF RID: 6143
		hairs,
		// Token: 0x04001800 RID: 6144
		hairaho,
		// Token: 0x04001801 RID: 6145
		haircolor,
		// Token: 0x04001802 RID: 6146
		skin,
		// Token: 0x04001803 RID: 6147
		acctatoo,
		// Token: 0x04001804 RID: 6148
		accnail,
		// Token: 0x04001805 RID: 6149
		underhair,
		// Token: 0x04001806 RID: 6150
		hokuro,
		// Token: 0x04001807 RID: 6151
		mayu,
		// Token: 0x04001808 RID: 6152
		lip,
		// Token: 0x04001809 RID: 6153
		eye,
		// Token: 0x0400180A RID: 6154
		eye_hi,
		// Token: 0x0400180B RID: 6155
		eye_hi_r,
		// Token: 0x0400180C RID: 6156
		chikubi,
		// Token: 0x0400180D RID: 6157
		chikubicolor,
		// Token: 0x0400180E RID: 6158
		eyewhite,
		// Token: 0x0400180F RID: 6159
		nose,
		// Token: 0x04001810 RID: 6160
		facegloss,
		// Token: 0x04001811 RID: 6161
		matsuge_up,
		// Token: 0x04001812 RID: 6162
		matsuge_low,
		// Token: 0x04001813 RID: 6163
		futae,
		// Token: 0x04001814 RID: 6164
		wear,
		// Token: 0x04001815 RID: 6165
		skirt,
		// Token: 0x04001816 RID: 6166
		mizugi,
		// Token: 0x04001817 RID: 6167
		bra,
		// Token: 0x04001818 RID: 6168
		panz,
		// Token: 0x04001819 RID: 6169
		stkg,
		// Token: 0x0400181A RID: 6170
		shoes,
		// Token: 0x0400181B RID: 6171
		headset,
		// Token: 0x0400181C RID: 6172
		glove,
		// Token: 0x0400181D RID: 6173
		acchead,
		// Token: 0x0400181E RID: 6174
		accha,
		// Token: 0x0400181F RID: 6175
		acchana,
		// Token: 0x04001820 RID: 6176
		acckamisub,
		// Token: 0x04001821 RID: 6177
		acckami,
		// Token: 0x04001822 RID: 6178
		accmimi,
		// Token: 0x04001823 RID: 6179
		accnip,
		// Token: 0x04001824 RID: 6180
		acckubi,
		// Token: 0x04001825 RID: 6181
		acckubiwa,
		// Token: 0x04001826 RID: 6182
		accheso,
		// Token: 0x04001827 RID: 6183
		accude,
		// Token: 0x04001828 RID: 6184
		accashi,
		// Token: 0x04001829 RID: 6185
		accsenaka,
		// Token: 0x0400182A RID: 6186
		accshippo,
		// Token: 0x0400182B RID: 6187
		accanl,
		// Token: 0x0400182C RID: 6188
		accvag,
		// Token: 0x0400182D RID: 6189
		megane,
		// Token: 0x0400182E RID: 6190
		accxxx,
		// Token: 0x0400182F RID: 6191
		handitem,
		// Token: 0x04001830 RID: 6192
		acchat,
		// Token: 0x04001831 RID: 6193
		onepiece,
		// Token: 0x04001832 RID: 6194
		set_maidwear,
		// Token: 0x04001833 RID: 6195
		set_mywear,
		// Token: 0x04001834 RID: 6196
		set_underwear,
		// Token: 0x04001835 RID: 6197
		set_body,
		// Token: 0x04001836 RID: 6198
		folder_eye,
		// Token: 0x04001837 RID: 6199
		folder_mayu,
		// Token: 0x04001838 RID: 6200
		folder_underhair,
		// Token: 0x04001839 RID: 6201
		folder_skin,
		// Token: 0x0400183A RID: 6202
		folder_eyewhite,
		// Token: 0x0400183B RID: 6203
		folder_matsuge_up,
		// Token: 0x0400183C RID: 6204
		folder_matsuge_low,
		// Token: 0x0400183D RID: 6205
		folder_futae,
		// Token: 0x0400183E RID: 6206
		kousoku_upper,
		// Token: 0x0400183F RID: 6207
		kousoku_lower,
		// Token: 0x04001840 RID: 6208
		seieki_naka,
		// Token: 0x04001841 RID: 6209
		seieki_hara,
		// Token: 0x04001842 RID: 6210
		seieki_face,
		// Token: 0x04001843 RID: 6211
		seieki_mune,
		// Token: 0x04001844 RID: 6212
		seieki_hip,
		// Token: 0x04001845 RID: 6213
		seieki_ude,
		// Token: 0x04001846 RID: 6214
		seieki_ashi
	}
	*/
}
