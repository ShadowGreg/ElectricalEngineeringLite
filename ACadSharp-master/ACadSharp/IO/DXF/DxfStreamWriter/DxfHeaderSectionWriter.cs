﻿using ACadSharp.Header;
using System.Collections.Generic;

namespace ACadSharp.IO.DXF
{
	internal class DxfHeaderSectionWriter : DxfSectionWriterBase
	{
		public override string SectionName { get { return DxfFileToken.HeaderSection; } }

		public CadHeader Header { get { return this._document.Header; } }

		public DxfHeaderSectionWriter(IDxfStreamWriter writer, CadDocument document, CadObjectHolder holder) : base(writer, document, holder)
		{
		}

		protected override void writeSection()
		{
			Dictionary<string, CadSystemVariable> map = CadHeader.GetHeaderMap();

			foreach (KeyValuePair<string, CadSystemVariable> item in map)
			{
				if (item.Value.ReferenceType.HasFlag(DxfReferenceType.Ignored))
					continue;

				if (item.Value.GetValue(this.Header) == null)
					continue;

				this._writer.Write(DxfCode.CLShapeText, item.Key);

				if (item.Key == "$HANDSEED")    //Not very elegant but by now...
				{
					this._writer.Write(DxfCode.Handle, this._document.Header.HandleSeed);
					continue;
				}

				foreach (var csv in item.Value.DxfCodes)
				{
					object value = item.Value.GetValue(csv, this._document.Header);

					if (value == null)
						continue;

					this._writer.Write((DxfCode)csv, value);
				}
			}
		}
	}
}
