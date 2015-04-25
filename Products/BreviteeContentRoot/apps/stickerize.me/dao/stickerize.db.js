var database = {
    nameSpace: "Brevitee.Stickerize.Data",
    schemaName: "Stickerize",
    xrefs: [
        ["Stickerizer", "Stickerizee"],
        ["StickerizableList", "Stickerizable"],
        ["SubSection", "Stickerizable"],
    ],
    tables: [
        {
            name: "LoginTime",
            cols: [
                { DateTime: "DateTime" },
                { UserName: "String" }
            ]
        },
        {
            name: "Stickerizer",
            fks: [
                { ImageId: "Image" },
                { CreationId: "Creation"}
            ],
            cols:[
                { Name: "String", Null: false },
                { DisplayName: "String" },
                { UserName: "String" }
            ]
        },
        {
            name: "Stickerizee",
            fks: [
                { ImageId: "Image" },
                { CreationId: "Creation" }
            ],
            cols:[
                { Name: "String", Null: false},
                { DisplayName: "String" },
                { Gender: "String", Null: false },
                { UserName: "String" }
            ]
        },
        {
            name: "Stickerizable",
            fks: [
                { CreationId: "Creation" }
            ],
            cols: [
                { Name: "String", Null: false},
                { Description: "String" },
                { For: "String", Null: false }
            ]
        },
        {
            name: "StickerizableList",
            fks: [
                { CreatorId: "Stickerizer" },
                { CreationId: "Creation" }
            ],
            cols: [
                { Name: "String", Null: false },
                { Description: "String" },
                { Public: "Boolean", Null: false }
            ]
        },
        {
            name: "Sticker",
            fks: [
                { ImageId: "Image" },
                { CreationId: "Creation" }
            ],
            cols: [
                { Name: "String", Null: false },
                { Description: "String" }
            ]
        },
        {
            name: "Stickerization",
            fks:[
                { StickerId: "Sticker" },
                { StickerizerId: "Stickerizer" },
                { StickerizableId: "Stickerizable" },
                { StickerizeeId: "Stickerizee" },
                { CreationId: "Creation"}
            ],
            cols: [
                { UndoneAt: "DateTime" },
                { IsUndone: "Boolean" }
            ]
        },
        {
            name: "Image",
            cols: [
                { Url: "String", Null: false }
            ]
        },
        {
            name: "Creation",
            cols: [
                { At: "DateTime" },
                { By: "String"}
            ]
        },
        {
            name: "SubSection",
            fks: [
                { StickerizableListId: "StickerizableList" },
                { CreationId: "Creation" }
            ],
            cols: [
                { Name: "String" }
            ]
        }
    ]
};
