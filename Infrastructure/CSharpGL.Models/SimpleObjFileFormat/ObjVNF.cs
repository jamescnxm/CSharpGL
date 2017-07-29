﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class ObjVNF : IBufferSource
    {
        public ObjVNF(string filename)
        {
            var generality = new GeneralityParser();
            var meshParser = new MeshParser();
            var normalParser = new NormalParser();


        }
        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            throw new NotImplementedException();
        }

        public IndexBuffer GetIndexBuffer()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
