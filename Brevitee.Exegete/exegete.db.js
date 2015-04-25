var database = {
    nameSpace: "Brevitee.Exegete",
    schemaName: "Exegete",
    xrefs: [
      
    ],
    tables: [
        {
            name: "Language",
            cols: [
                { EnglishName: "String", Null: false },
                { AllEnglishNames: "String", Null: false },
                { AllFrenchNames: "String", Null: false },
                { ISO639_2: "String", Null: false },
                { ISO639_1: "String", Null: false}
            ]
        },
        {
            name: "Text",
            fks: [
                { LanguageId: "Long" }
            ],
            cols: [
                { Value: "String", Null: false }
            ]
        },
        {
            name: "Translation",
            fks: [
                { TextId: "Text" },
                { LanguageId: "Language" }
            ],
            cols: [
                { TranslatorUuid: "String", Null: false },
                { Value: "String", Null: false }
            ]
        }
    ]
};
