var database = {
    nameSpace: "Brevitee.Data.Repositories.Tests",
    schemaName: "RepoTests",
    xrefs: [
        ["SecondaryObject", "TernaryObject"]
    ],
    tables: [
        {
            name: "MainObject",
            cols: [
                { Created: "DateTime" },
                { Name: "String" }
            ]
        },
        {
            name: "SecondaryObject",
            fks: [
                { MainId: "MainObject" }
            ],
            cols: [
                { Created: "DateTime", Null: false },
                { Name: "String", Null: false }                
            ]
        },
        {
            name: "TernaryObject",
            cols: [
                { Created: "DateTime", Null: false },
                { Name: "String", Null: false}
            ]
        }
    ]
};
