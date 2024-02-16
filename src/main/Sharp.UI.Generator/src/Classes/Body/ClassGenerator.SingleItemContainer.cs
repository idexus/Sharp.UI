//
// MIT License
// Copyright Pawel Krzywdzinski
//

using System;
using Microsoft.CodeAnalysis;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Sharp.UI.Generator.Classes
{
    public partial class ClassGenerator
    {        
        void GenerateSingleItemContainer()
        {
            if (containerOfTypeName != null && isSingleItemContainer == true)
            {
                var newPrefix = isNewPropertyContainer ? " new" : "";

                builder.AppendLine($@"
        // ----- single item container -----

        IEnumerator IEnumerable.GetEnumerator() {{ yield return this.{contentPropertyName}; }}
        public{newPrefix} void Add({containerOfTypeName} {contentPropertyName.ToLower()}) => this.{contentPropertyName} = {contentPropertyName.ToLower()};");
            }
        }
    }
}