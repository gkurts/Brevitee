var database = {
    nameSpace: "Brevitee.DaoRef",
    schemaName: "DaoRef",
    xrefs: [
        ["Left", "Right"]
    ],
    tables: [
        {
            name: "Left",
            cols: [
                { Name: "String", Null: false }
            ]
        },
        {
            name: "Right",
            cols: [
                { Name: "String", Null: false }
            ]
        },
        {
            name: "TestTable",
            cols: [
                { Name: "String", Null: false },
                { Description: "String" }
            ]
        },
        {
            name: "TestFkTable",
            fks: [
                { TestTableId: "TestTable" }
            ],
            cols: [
                { Name: "String", Null: false }
            ]
        },
        {
            name: "DaoReferenceObject",
            cols: [
                { IntProperty: "Int" },
                { DecimalProperty: "Decimal" },
                { LongProperty: "Long" },
                { DateTimeProperty: "DateTime" },
                { BoolProperty: "Boolean" },
                { ByteArrayProperty: "Byte" },
                { StringProperty: "String" }
            ]
        },
        {
            name: "DaoReferenceObjectWithForeignKey",
            fks: [
                { DaoReferenceObjectId: "DaoReferenceObject" }
            ],
            cols: [
                { Name: "String", Null: false }
            ]
        }
    ]
}
