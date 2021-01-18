﻿using System.Collections.Generic;
using System.IO;
using ME2Randomizer.Classes.Randomizers.Utility;
using ME3ExplorerCore.Helpers;
using ME3ExplorerCore.Packages;
using ME3ExplorerCore.Unreal;

namespace ME2Randomizer.Classes.Randomizers.ME2.TextureAssets
{
    public static class ME2Textures
    {
        public static void SetupME2Textures()
        {
            var options = new List<RTexture2D>
            {
                new RTexture2D
                {
                    // The orange datapad you see everyone holding
                    TextureInstancedFullPath = "BioApl_Dec_DataPad01.Materials.Datapad01_Screen",
                    AllowedTextureAssetNames = new List<string>
                    {
                        "DatapadScreens.Datapad01_Screen.map.bin",
                        "DatapadScreens.Datapad01_Screen.monsterplan.bin",
                        "DatapadScreens.Datapad01_Screen.sizebounty.bin",
                        "DatapadScreens.Datapad01_Screen.thisisfine.bin",
                    }
                },
                new RTexture2D
                {
                    // The end-of-game datapad texture
                    TextureInstancedFullPath = "BioVFX_Env_End.Textures.Reaper_Display",
                    AllowedTextureAssetNames = new List<string>
                    {
                        "DatapadScreens.Reaper_Display.fishdog_foodshack.bin",
                    }
                },
                new RTexture2D
                {
                    // The graphs that scroll by (H_Graphs)
                    TextureInstancedFullPath = "BioVFX_Env_Hologram.Textures.H_Graphs",
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_VFX", 513),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "HoloScreens.H_Graphs.pizzaonion.bin",
                    },
                    PreMountTexture = true
                },
                new RTexture2D
                {
                    // The graphs that scroll by, line and bar rchargs (H_Graphs3_5)
                    TextureInstancedFullPath = "BioVFX_Env_Hologram.Textures.H_Graphs2",
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_VFX", 513),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "HoloScreens.H_Graphs2.neonbolt.bin",
                    },
                    PreMountTexture = false // Texture isn't used anywhere before DLC mount
                },
                new RTexture2D
                {
                    // The graphs that scroll by, line and bar rchargs (H_Graphs3_5)
                    TextureInstancedFullPath = "BioVFX_Env_Hologram.Textures.H_Graphs3_5",
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_VFX", 513),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "HoloScreens.H_Graphs3_5.sonicburger.bin",
                    },
                    PreMountTexture = false // Texture isn't used anywhere before DLC mount
                },
                new RTexture2D
                {
                    // Vertically scrolling text (1)
                    TextureInstancedFullPath = "BioVFX_Env_Hologram.Textures.H_texts",
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_VFX", 513),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "HoloScreens.H_texts.sourdough.bin",
                        "HoloScreens.H_texts.newspaper.bin",
                    },
                    PreMountTexture = true
                },
                new RTexture2D
                {
                    // Vertically scrolling text (2)
                    TextureInstancedFullPath = "BioVFX_Env_Hologram.Textures.H_texts_2",
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_VFX", 513),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "HoloScreens.H_texts_2.vim.bin",
                    },
                    PreMountTexture = true
                },
                new RTexture2D
                {
                    // Vertically scrolling text (2)
                    TextureInstancedFullPath = "BioVFX_Env_Hologram.Textures.H_texts_3",
                    // purposely lower res than others.
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_VFX", 513),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "HoloScreens.H_texts_3.visualstudio.bin",
                    },
                    PreMountTexture = false
                },
                new RTexture2D
                {
                    // The picture frame that archer holds up in Overlord DLC act 2 start
                    TextureInstancedFullPath = "BioVFX_Env_UNC_Pack01.Textures.archer_photograph",
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_VFX", 513),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "PictureFrames.scarymiranda.bin",
                        "PictureFrames.creepyshep.bin",
                        "PictureFrames.hungryillusiveman.bin",
                        "PictureFrames.monkaanderson.bin",
                        "PictureFrames.longfaceudina.bin",
                    }
                },
                new RTexture2D()
                {
                    // The picture shown on the screen in the beginning of overlord DLC
                    TextureInstancedFullPath = "BioVFX_Env_UNC_Pack01.Textures.UNC_1_Dish_Display",
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_Promotional", 0),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "Overlord.satimg1.bin",
                    }
                },
                new RTexture2D()
                {
                    // Liara Love Interest Pic (Only if no romance is chosen)
                    TextureInstancedFullPath = "BioVFX_Env_Hologram.Textures.Liara_1",
                    LODGroup = new EnumProperty(new NameReference("TEXTUREGROUP_VFX", 513),"TextureGroup", MEGame.ME2, "LODGroup"), // A bit higher quality
                    AllowedTextureAssetNames = new List<string>
                    {
                        "PictureFrames.LoveInterests.steak.bin",
                    }
                }
            };

            // Start the new TFC
            TFCBuilder.StartNewTFCs(options);
        }
    }
}
