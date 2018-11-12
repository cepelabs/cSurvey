Namespace cSurvey.Design.Items
    Public Interface cIItemSign
        Enum SignSizeEnum
            [Default] = 0
            VerySmall = 1
            Small = 2
            Medium = 3
            Large = 4
            VeryLarge = 5
            x6 = 6
            x8 = 7
            x10 = 8
            x12 = 9
            x16 = 10
        End Enum

        Enum SignRotateModeEnum
            Rotable = 0
            Fixed = 1
        End Enum

        'symbolic passage fills:13 bedrock, sand, raft, clay, pebbles, debris, blocks, water,
        'ice, guano, snow;

        'speleothems: flowstone, moonmilk, stalactite, stalagmite, pillar, curtain, helictite,
        'soda-straw, crystal, wall-calcite, popcorn, disk, gypsum, gypsumflower,
        'aragonite, cave-pearl, rimstone-pool, rimstone-dam, anastomosis, karren,
        'scallop, flute, raft-cone, clay-tree; 5.4
        'equipment: anchor, rope, fixed-ladder, rope-ladder, steps, bridge, traverse,
        'camp, no-equipment;
        'passage ends: continuation, narrow-end, low-end, flowstone-choke, breakdown-
        'choke, clay-choke, entrance;
        'others: dig, archeo-material, paleo-
        Enum SignCategoryEnum
            Mask = &HF00
            Undefined = 0
            Speleothems = 512
            Equipment = 1024
            PassageEnds = 256
            Others = 768
            SymbolicPassageFills = 1280
        End Enum

        Enum SignEnum
            Undefined = 0

            'PassageEnds = 256
            Continuation = 257
            NarrowEnd = 258
            LowEnd = 259
            FlowstoneChoke = 260
            BreakdownChoke = 261
            ClayChoke = 262
            Entrance = 263

            'Speleothems = 512
            FlowStone = 513
            Moonmilk = 514
            Stalactite = 515
            Stalactites = 516
            Stalagmite = 517
            Stalagmites = 518
            Pillar = 519
            Pillars = 520
            Curtain = 521
            SodaStraw = 522
            Popcorn = 523
            CavePearl = 524
            Disk = 525
            Helictite = 526
            Aragonite = 527
            Crystal = 528
            WallCalcite = 529
            Gypsum = 530
            GypsumFlower = 531
            Anastomosis = 532
            Karren = 533
            Scallop = 534
            Flute = 535
            RaftCone = 536
            ClayTree = 537
            RimstonePool = 538
            RimstoneDam = 539

            'Others = 768
            ArcheoMaterial = 769
            PaleoMaterial = 770
            VegetableDebris = 771
            Root = 772
            Dig = 773
            AirDraught = 774
            AirDraughtSummer = 775
            AirDraughtWinter = 776
            WaterFlow = 777
            WaterFlowIntermittent = 778
            WaterFlowPaleo = 779
            Waterfall = 780
            Spring = 781
            Sink = 782
            IceStalactite = 783
            IceStalagmite = 784
            IcePillar = 785
            Gradient = 786

            'Equipment = 1024
            Camp = 1025
            Anchor = 1026
            Rope = 1027
            RopeLadder = 1028  'scaletta mobile
            FixedLadder = 1029 'scaletta fissa
            Steps = 1030
            ViaFerrata = 1031
            Traverse = 1032
            Bridge = 1033
            Handrail = 1034

            'SymbolicPassageFills = 1280
            Ice = 1281
            Snow = 1282
            Water = 1283
            Pebbles = 1284
            Clay = 1285
            Raft = 1286
            Guano = 1287
            Sand = 1288
            Debrits = 1289
            Blocks = 1290
            Rock = 1291
        End Enum

        Property SignRotateMode() As SignRotateModeEnum
        Property SignSize As SignSizeEnum

        Property Sign As SignEnum
        'Property SignCategory As SignCategoryEnum

        Property SignRotationAngleDelta As Single

        ReadOnly Property Clipart As cClipart
    End Interface
End Namespace