﻿using Com.Danliris.Service.Packing.Inventory.Application.CommonViewModelObjectProperties;
using Com.Danliris.Service.Packing.Inventory.Application.ToBeRefactored.DyeingPrintingAreaInput.Aval;
using Com.Danliris.Service.Packing.Inventory.Application.ToBeRefactored.DyeingPrintingAreaOutput.Aval;
using Com.Danliris.Service.Packing.Inventory.Data.Models.DyeingPrintingAreaMovement;
using Com.Danliris.Service.Packing.Inventory.Infrastructure.Repositories.DyeingPrintingAreaMovement;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.Danliris.Service.Packing.Inventory.Test.Services
{
    public class OutputAvalServiceTest
    {
        public OutputAvalService GetService(IServiceProvider serviceProvider)
        {
            return new OutputAvalService(serviceProvider);
        }

        public Mock<IServiceProvider> GetServiceProvider(IDyeingPrintingAreaInputRepository inputRepo,
                                                         IDyeingPrintingAreaOutputRepository outputRepo,
                                                         IDyeingPrintingAreaMovementRepository movementRepo,
                                                         IDyeingPrintingAreaSummaryRepository summaryRepo,
                                                         IDyeingPrintingAreaInputProductionOrderRepository inputProductionOrderRepo)
        {
            var spMock = new Mock<IServiceProvider>();

            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaInputRepository)))
                .Returns(inputRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaOutputRepository)))
                .Returns(outputRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaMovementRepository)))
                .Returns(movementRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaSummaryRepository)))
                .Returns(summaryRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaInputProductionOrderRepository)))
                .Returns(inputProductionOrderRepo);
            //spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaInputProductionOrderRepository)))
            //    .Returns(new DyeingPrintingAreaInputProductionOrderRepository());

            return spMock;
        }
        public Mock<IServiceProvider> GetServiceProvider(IDyeingPrintingAreaInputRepository inputRepo,
                                                        IDyeingPrintingAreaOutputRepository outputRepo,
                                                        IDyeingPrintingAreaMovementRepository movementRepo,
                                                        IDyeingPrintingAreaSummaryRepository summaryRepo,
                                                        IDyeingPrintingAreaInputProductionOrderRepository inputProductionOrderRepo,
                                                        IDyeingPrintingAreaOutputProductionOrderRepository outputProductionOrderRepo)
        {
            var spMock = new Mock<IServiceProvider>();

            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaInputRepository)))
                .Returns(inputRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaOutputRepository)))
                .Returns(outputRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaMovementRepository)))
                .Returns(movementRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaSummaryRepository)))
                .Returns(summaryRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaInputProductionOrderRepository)))
                .Returns(inputProductionOrderRepo);
            spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaOutputProductionOrderRepository)))
                .Returns(outputProductionOrderRepo);
            //spMock.Setup(s => s.GetService(typeof(IDyeingPrintingAreaInputProductionOrderRepository)))
            //    .Returns(new DyeingPrintingAreaInputProductionOrderRepository());

            return spMock;
        }
        private OutputAvalViewModel ViewModel
        {
            get
            {
                return new OutputAvalViewModel()
                {
                    Area = "GUDANG AVAL",
                    Date = DateTimeOffset.UtcNow,
                    DestinationArea = "SHIPPING",
                    Shift = "PAGI",
                    Type = "OUT",
                    BonNo = "GA.20.0001",
                    Group = "A",
                    DeliveryOrderSalesNo = "Do01",
                    DeliveryOrdeSalesId = 1,
                    HasNextAreaDocument = false,
                    AvalItems = new List<OutputAvalItemViewModel>()
                    {
                        new OutputAvalItemViewModel()
                        {
                            AvalItemId = 122,
                            AvalType = "KAIN KOTOR",
                            AvalCartNo = "5",
                            AvalUomUnit = "MTR",
                            AvalQuantity = 5,
                            AvalQuantityKg = 1,
                            AvalOutQuantity = 1,
                            AvalOutSatuan= 1
                        }
                    },
                    DyeingPrintingMovementIds = new List<OutputAvalDyeingPrintingAreaMovementIdsViewModel>()
                    {
                        new OutputAvalDyeingPrintingAreaMovementIdsViewModel()
                        {
                            DyeingPrintingAreaMovementId = 51,
                            AvalItemId = 122
                        }
                    }
                };
            }
        }

        private OutputAvalViewModel ViewModelAdj
        {
            get
            {
                return new OutputAvalViewModel()
                {
                    Area = "GUDANG AVAL",
                    Date = DateTimeOffset.UtcNow,
                    DestinationArea = "SHIPPING",
                    Shift = "PAGI",
                    Type = "ADJ",
                    BonNo = "GA.20.0001",
                    Group = "A",
                    DeliveryOrderSalesNo = "Do01",
                    DeliveryOrdeSalesId = 1,
                    HasNextAreaDocument = false,
                    AvalItems = new List<OutputAvalItemViewModel>()
                    {
                        new OutputAvalItemViewModel()
                        {
                            AvalItemId = 122,
                            AvalType = "KAIN KOTOR",
                            AvalCartNo = "5",
                            AvalUomUnit = "MTR",
                            AvalQuantity = -5,
                            AvalQuantityKg = -1,
                            AvalOutQuantity = 1,
                            AvalOutSatuan= 1,
                            AdjDocumentNo = "a",
                        }
                    },
                    DyeingPrintingMovementIds = new List<OutputAvalDyeingPrintingAreaMovementIdsViewModel>()
                    {
                        new OutputAvalDyeingPrintingAreaMovementIdsViewModel()
                        {
                            DyeingPrintingAreaMovementId = 51,
                            AvalItemId = 122
                        }
                    }
                };
            }
        }

        private DyeingPrintingAreaOutputModel OutputModel
        {
            get
            {
                return new DyeingPrintingAreaOutputModel(ViewModel.Date,
                                                         ViewModel.Area,
                                                         ViewModel.Shift,
                                                         ViewModel.BonNo,
                                                         false,
                                                         ViewModel.DestinationArea,
                                                         ViewModel.Group,
                                                         ViewModel.AvalItems.Select(s => new DyeingPrintingAreaOutputProductionOrderModel(
                                                             ViewModel.Area, true, s.AvalType, s.AvalQuantity, s.AvalQuantityKg, s.AdjDocumentNo)).ToList());
            }
        }

        private DyeingPrintingAreaOutputModel OutputModelAdj
        {
            get
            {
                return new DyeingPrintingAreaOutputModel(ViewModelAdj.Date, ViewModelAdj.Area, ViewModelAdj.Shift, ViewModelAdj.BonNo, ViewModelAdj.HasNextAreaDocument,ViewModelAdj.DestinationArea,
                    ViewModelAdj.Group, ViewModelAdj.Type, ViewModelAdj.AvalItems.Select(s => new DyeingPrintingAreaOutputProductionOrderModel(
                                                             ViewModelAdj.Area, true, s.AvalType, s.AvalQuantity, s.AvalQuantityKg, s.AdjDocumentNo)).ToList());
            }
        }

        private DyeingPrintingAreaOutputModel OutputModelExist
        {
            get
            {
                return new DyeingPrintingAreaOutputModel(ViewModel.Date,
                                                         ViewModel.Area,
                                                         ViewModel.Shift,
                                                         ViewModel.BonNo,
                                                         ViewModel.DeliveryOrderSalesNo,
                                                         ViewModel.DeliveryOrdeSalesId,
                                                         false,
                                                         ViewModel.DestinationArea,
                                                         ViewModel.Group,
                                                         ViewModel.AvalItems.Select(s => new DyeingPrintingAreaOutputProductionOrderModel(
                                                             ViewModel.Area, true, s.AvalType, s.AvalQuantity, s.AvalQuantityKg, s.AdjDocumentNo)).ToList());
            }
        }
        private DyeingPrintingAreaOutputModel OutputEmptyModel
        {
            get
            {
                return new DyeingPrintingAreaOutputModel(ViewModel.Date,
                                                         ViewModel.Area,
                                                         ViewModel.Shift,
                                                         ViewModel.BonNo,
                                                         false,
                                                         ViewModel.DestinationArea,
                                                         ViewModel.Group,
                                                         new List<DyeingPrintingAreaOutputProductionOrderModel>());
            }
        }
        private InputAvalViewModel ViewModelInput
        {
            get
            {
                return new InputAvalViewModel()
                {
                    Area = "GUDANG AVAL",
                    Date = DateTimeOffset.UtcNow,
                    Shift = "PAGI",
                    BonNo = "GA.20.0001",
                    Group = "A",
                    AvalItems = new List<InputAvalItemViewModel>()
                    {
                        new InputAvalItemViewModel()
                        {
                            AvalType = "KAIN KOTOR",
                            AvalCartNo = "5",
                            AvalUomUnit = "MTR",
                            AvalQuantity = 5,
                            AvalQuantityKg = 1,
                            HasOutputDocument = false,
                            IsChecked = false,
                            Area = "INSPECTION MATERIAL"
                        }
                    },
                    DyeingPrintingMovementIds = new List<InputAvalDyeingPrintingAreaMovementIdsViewModel>()
                    {
                        new InputAvalDyeingPrintingAreaMovementIdsViewModel()
                        {
                            DyeingPrintingAreaMovementId = 51,
                            ProductionOrderIds = new List<int>()
                            {
                                11,
                                12
                            }
                        }
                    }
                };
            }
        }
        private DyeingPrintingAreaInputModel ModelInput
        {
            get
            {
                return new DyeingPrintingAreaInputModel(ViewModelInput.Date,
                                                        ViewModelInput.Area,
                                                        ViewModelInput.Shift,
                                                        ViewModelInput.BonNo,
                                                        ViewModelInput.Group,
                                                        "KAIN KOTOR",
                                                        true,
                                                        10,
                                                        10,
                                                        ViewModelInput.AvalItems.Select(s => new DyeingPrintingAreaInputProductionOrderModel(ViewModelInput.Area,
                                                                                                                                        s.AvalType,
                                                                                                                                        s.AvalCartNo,
                                                                                                                                        s.AvalUomUnit,
                                                                                                                                        s.AvalQuantity,
                                                                                                                                        s.AvalQuantityKg,
                                                                                                                                        false))
                                                                           .ToList());
            }
        }

        [Fact]
        public async Task Should_Success_Create()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            //Mock for totalCurrentYear
            outputRepoMock.Setup(s => s.ReadAllIgnoreQueryFilter())
                .Returns(new List<DyeingPrintingAreaOutputModel>() { OutputModel }.AsQueryable());

            //Mock for Create New Row in Input and ProductionOrdersInput in Each Repository 
            outputRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaOutputModel>()))
                .ReturnsAsync(1);

            inputProductionOrdersRepoMock.Setup(s => s.GetInputProductionOrder(It.IsAny<int>()))
                .Returns(new DyeingPrintingAreaInputProductionOrderModel(It.IsAny<string>(),
                                                                         It.IsAny<string>(),
                                                                         It.IsAny<string>(),
                                                                         It.IsAny<string>(),
                                                                         It.IsAny<int>(),
                                                                         It.IsAny<int>(),
                                                                         It.IsAny<bool>()));

            inputProductionOrdersRepoMock.Setup(s => s.UpdateFromOutputAsync(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(1);

            summaryRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaSummaryModel>()))
                 .ReturnsAsync(1);

            movementRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaMovementModel>()))
                 .ReturnsAsync(1);

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = await service.Create(ViewModel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Create_bonExist()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();
            var outputSppRepoMock = new Mock<IDyeingPrintingAreaOutputProductionOrderRepository>();
            //OutputModel.SetDeliveryOrderSales( ViewModel.DeliveryOrdeSalesId,ViewModel.DeliveryOrderSalesNo,"unitetest","unittest");
            //var outputmodel = OutputModel;
            //Mock for totalCurrentYear
            outputRepoMock.Setup(s => s.ReadAllIgnoreQueryFilter())
                .Returns(new List<DyeingPrintingAreaOutputModel>() { OutputModelExist }.AsQueryable());

            outputRepoMock.Setup(s => s.ReadAll())
                .Returns(new List<DyeingPrintingAreaOutputModel>() { OutputModelExist }.AsQueryable());
            outputSppRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaOutputProductionOrderModel>()))
                .ReturnsAsync(1);
            //Mock for Create New Row in Input and ProductionOrdersInput in Each Repository 
            outputRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaOutputModel>()))
                .ReturnsAsync(1);

            var test = ModelInput;
            test.SetIsTransformedAval(true, "unittest", "unittest");
            inputRepoMock.Setup(s => s.ReadAll())
                .Returns(new List<DyeingPrintingAreaInputModel> { test }.AsQueryable());



            inputProductionOrdersRepoMock.Setup(s => s.GetInputProductionOrder(It.IsAny<int>()))
                .Returns(new DyeingPrintingAreaInputProductionOrderModel(It.IsAny<string>(),
                                                                         It.IsAny<string>(),
                                                                         It.IsAny<string>(),
                                                                         It.IsAny<string>(),
                                                                         It.IsAny<int>(),
                                                                         It.IsAny<int>(),
                                                                         It.IsAny<bool>()));

            inputProductionOrdersRepoMock.Setup(s => s.UpdateFromOutputAsync(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(1);

            summaryRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaSummaryModel>()))
                 .ReturnsAsync(1);

            movementRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaMovementModel>()))
                 .ReturnsAsync(1);

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object,
                                                        outputSppRepoMock.Object).Object);

            var result = await service.Create(ViewModel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_CreateAdj()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();
            var outputSppRepoMock = new Mock<IDyeingPrintingAreaOutputProductionOrderRepository>();

            outputRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaOutputModel>()))
                .ReturnsAsync(1);

            movementRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaMovementModel>()))
                 .ReturnsAsync(1);
            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object,
                                                        outputSppRepoMock.Object).Object);
            var result = await service.Create(ViewModelAdj);

            Assert.NotEqual(0, result);
        }


        [Fact]
        public async Task Should_Success_CreateAdjIn()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();
            var outputSppRepoMock = new Mock<IDyeingPrintingAreaOutputProductionOrderRepository>();

            outputRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaOutputModel>()))
                .ReturnsAsync(1);

            movementRepoMock.Setup(s => s.InsertAsync(It.IsAny<DyeingPrintingAreaMovementModel>()))
                 .ReturnsAsync(1);
            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object,
                                                        outputSppRepoMock.Object).Object);
            var vm = ViewModelAdj;
            foreach (var item in vm.AvalItems)
            {
                item.AvalQuantity = 1;
                item.AvalQuantityKg = 5;
            }

            var result = await service.Create(vm);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public void Should_Success_Read()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            outputRepoMock.Setup(s => s.ReadAll())
                 .Returns(new List<DyeingPrintingAreaOutputModel>() { OutputModel }.AsQueryable());

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = service.Read(1, 25, "{}", "{}", null);

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public void Should_Success_ReadAllAvailableAval()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            inputRepoMock.Setup(s => s.ReadAll())
                 .Returns(new List<DyeingPrintingAreaInputModel>() { ModelInput }.AsQueryable());

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = service.ReadAllAvailableAval(1, 25, "{}", "{}", null);

            Assert.NotEmpty(result.Data);
        }
        [Fact]
        public void Should_Success_ReadByBonAvailableAval()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            inputRepoMock.Setup(s => s.ReadAll())
                 .Returns(new List<DyeingPrintingAreaInputModel>() { ModelInput }.AsQueryable());

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = service.ReadByBonAvailableAval(0, 1, 25, "{}", "{}", null);

            Assert.NotEmpty(result.Data);
        }
        [Fact]
        public void Should_Success_ReadByTypeAvailableAval()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            var test = ModelInput;
            test.SetIsTransformedAval(true, "unittest", "unittest");

            inputRepoMock.Setup(s => s.ReadAll())
                 .Returns(new List<DyeingPrintingAreaInputModel>() { test }.AsQueryable());

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = service.ReadByTypeAvailableAval("KAIN KOTOR", 1, 25, "{ }", "{}", null);

            Assert.NotEmpty(result.Data);
        }
        [Fact]
        public void Should_Success_ReadAvailableAval()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            inputRepoMock.Setup(s => s.ReadAll())
                 .Returns(new List<DyeingPrintingAreaInputModel>()
                 {
                     new DyeingPrintingAreaInputModel(DateTimeOffset.UtcNow,
                                                      "GUDANG AVAL",
                                                      "PAGI",
                                                      "IM.GA.20.0001",
                                                      "A",
                                                      new List<DyeingPrintingAreaInputProductionOrderModel>()
                                                      {
                                                          new DyeingPrintingAreaInputProductionOrderModel("GUDANG AVAL",
                                                                                                          "SAMBUNGAN",
                                                                                                          "5-11",
                                                                                                          "KRG",
                                                                                                          1,
                                                                                                          10,
                                                                                                          false)
                     })
                 }.AsQueryable());

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = service.ReadAvailableAval(DateTimeOffset.UtcNow, "PAGI", "A", 1, 25, "{}", "{}", null);

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Should_Success_ReadById()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            outputRepoMock.Setup(s => s.ReadByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(OutputModel);

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = await service.ReadById(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Null_ReadById()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            outputRepoMock.Setup(s => s.ReadByIdAsync(It.IsAny<int>()))
               .ReturnsAsync(default(DyeingPrintingAreaOutputModel));

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = await service.ReadById(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task Should_Success_GenerateExcel()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            outputRepoMock.Setup(s => s.ReadByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(OutputModel);

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = await service.GenerateExcel(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Empty_GenerateExcel()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            outputRepoMock.Setup(s => s.ReadByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(OutputEmptyModel);

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);

            var result = await service.GenerateExcel(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void Should_Success_GeneratedBon()
        {
            var inputRepoMock = new Mock<IDyeingPrintingAreaInputRepository>();
            var outputRepoMock = new Mock<IDyeingPrintingAreaOutputRepository>();
            var movementRepoMock = new Mock<IDyeingPrintingAreaMovementRepository>();
            var summaryRepoMock = new Mock<IDyeingPrintingAreaSummaryRepository>();
            var inputProductionOrdersRepoMock = new Mock<IDyeingPrintingAreaInputProductionOrderRepository>();

            var service = GetService(GetServiceProvider(inputRepoMock.Object,
                                                        outputRepoMock.Object,
                                                        movementRepoMock.Object,
                                                        summaryRepoMock.Object,
                                                        inputProductionOrdersRepoMock.Object).Object);
            var res1 = service.GenerateBonNo(1, DateTimeOffset.UtcNow, "SHIPPING");
            var res2 = service.GenerateBonNo(1, DateTimeOffset.UtcNow, "PENJUALAN");
            var res3 = service.GenerateBonNo(1, DateTimeOffset.UtcNow, "BUYER");
            var res4 = service.GenerateBonNo(1, DateTimeOffset.UtcNow, "test");

            Assert.NotNull(res1);
            Assert.NotNull(res2);
            Assert.NotNull(res3);
            Assert.NotNull(res4);


        }

        [Fact]
        public void Should_Success_GetSetModel()
        {
            var test = ViewModel;
            var did = test.DeliveryOrdeSalesId;
            var dno = test.DeliveryOrderSalesNo;
            var nexArea = test.HasNextAreaDocument;
            var dpIds = test.DyeingPrintingMovementIds;
            Assert.NotNull(test);
        }
    }
}
