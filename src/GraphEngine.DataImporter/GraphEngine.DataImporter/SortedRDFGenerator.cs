using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEngine.DataImporter
{
    using Trinity;
    using Trinity.Storage;
    using static RDFUtils;
    internal class SortedRDFTSLGenerator : IGenerator<List<string>>
    {
        public void Scan(List<string> entity)
        {
            var typeGroups = entity.Select(ParseTriple).Where(_ => _.Subject != null).GroupBy(_ => GetTypeName(_.Predicate)).ToList();

            if (typeGroups.Count == 0) return;

            var cellId = MID2CellId(typeGroups[0].First().Subject);

            var metaCell = new MetaCell(cellId, Fields: new List<MetaField>())
            {
                TypeId = -1 //mark type id to -1, indicating that this a multi-typed cell TODO constant
            };

            foreach (var typeGroup in typeGroups)
            {
                string type   = typeGroup.Key;
                int    typeId = TSLGenerator.GetTypeId(type);

                foreach (var propertyInstances in typeGroup.GroupBy(_ => GetTslName(_.Predicate)))
                {
                    string    property  = propertyInstances.Key;
                    int       fieldId   = TSLGenerator.GetFieldId(property);
                    bool      isList    = propertyInstances.Count() > 1;

                    var fieldType = propertyInstances.Aggregate(FieldType.ft_byte, (v, current) =>
                    {
                        var currentFt = GetFieldType(ref current);
                        return TSLGenerator.UpdateFieldType(v, currentFt);
                    });

                    MetaField field = new MetaField { fieldId = fieldId, fieldType = fieldType, isList = isList, typeId = typeId };

                    metaCell.Fields.Add(field);
                }
            }

            Global.LocalStorage.SaveMetaCell(metaCell);
        }

        public IEnumerable<List<string>> PreprocessInput(IEnumerable<string> input)
        {
            return GroupSortedLinesBySubject(input);
        }

        public void SetType(string type)
        {
            //Ignore the type
            return;
        }
    }
}