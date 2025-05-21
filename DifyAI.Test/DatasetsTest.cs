using DifyAI.ObjectModels;

namespace DifyAI.Test
{
    public class DatasetsTest : TestBase
    {
        [Fact]
        public async Task DatasetCreateUpdateDelete()
        {
            // create dataset
            var reqDatasetCreate = new DatasetCreateRequest
            {
                Name = $"test{DateTime.UtcNow.ToString("yyMMddHHmmssfff")}",
            };
            var rspDatasetCreate = await _difyAIService.Datasets.CreateDatasetAsync(reqDatasetCreate);
            Assert.NotNull(rspDatasetCreate.Id);

            // list datasets
            var listReq = new DatasetListRequest() { Page = 1, Limit = 20 };
            var rspDatasets = await _difyAIService.Datasets.GetDatasetsAsync(listReq);
            Assert.True(rspDatasets.Data.Count > 0);
            var found = false;
            foreach (var dataset in rspDatasets.Data)
            {
                if (dataset.Id == rspDatasetCreate.Id)
                {
                    found = true;
                    break;
                }
            }
            Assert.True(found);

            //delete the dataset
            await _difyAIService.Datasets.DeleteDatasetAsync(new DatasetDeleteRequest { DatasetId = rspDatasetCreate.Id });

            // list datasets to confirm the dataset is deleted
            rspDatasets = await _difyAIService.Datasets.GetDatasetsAsync(listReq);
            Assert.True(rspDatasets.Data.Count > 0);
            found = false;
            foreach (var dataset in rspDatasets.Data)
            {
                if (dataset.Id == rspDatasetCreate.Id)
                {
                    found = true;
                    break;
                }
            }
            Assert.False(found);
        }

        [Fact]
        public async Task CreateAndUpdateDocumentByText()
        {
            // create dataset
            var reqDatasetCreate = new DatasetCreateRequest
            {
                Name = $"test{DateTime.UtcNow.ToString("yyMMddHHmmssfff")}",
            };
            var rspDatasetCreate = await _difyAIService.Datasets.CreateDatasetAsync(reqDatasetCreate);

            try
            {
                //create document in the dataset
                var reqDocCreateTxt = new DocumentUpsetByTextRequest
                {
                    Name = "test2",
                    Text = "这是一个测试文档2",
                    DatasetId = rspDatasetCreate.Id,
                    IndexingTechnique = DocumentUpsetByTextRequest.IndexingTechniqueEconomy,
                    ProcessRule = new DatasetProcessRule()
                    {
                        Mode = DatasetProcessRule.ModeAutomatic
                    }
                };
                var rspDocCreateTxt = await _difyAIService.Datasets.CreateDocumentByTextAsync(reqDocCreateTxt);
                Assert.NotNull(rspDocCreateTxt.Document.Id);

                var progressCompleted = false;
                var count = 0;
                var maxCount = 20;
                while(!progressCompleted && count < maxCount)
                {
                    await Task.Delay(500);
                    var embeddingRsp = await _difyAIService.Datasets.GetDocumentsEmbeddingAsync(new DocumentEmbeddingRequest { DatasetId = rspDatasetCreate.Id, Batch = rspDocCreateTxt.Batch });
                    if (embeddingRsp.Data[0].IndexingStatus == "completed")
                    {
                        progressCompleted = true;
                    }
                    else
                    {
                        count++;
                    }
                }
                Assert.True(progressCompleted);

                //update document in the dataset
                var reqUpdate = new DocumentUpdateByTextRequest
                {
                    DatasetId = rspDatasetCreate.Id,
                    DocumentId = rspDocCreateTxt.Document.Id,
                    Name = "test2_update",
                    Text = "这是一个测试文档2 update",
                    IndexingTechnique = DocumentUpsetByTextRequest.IndexingTechniqueEconomy,
                    ProcessRule = new DatasetProcessRule()
                    {
                        Mode = DatasetProcessRule.ModeAutomatic
                    }
                };
                var rspUpdate = await _difyAIService.Datasets.UpdateDocumentByTextAsync(reqUpdate);
                Assert.Equal(rspDocCreateTxt.Document.Id, rspUpdate.Document.Id);

                // list documents in the dataset
                var reqList = new DocumentListRequest
                {
                    DatasetId = rspDatasetCreate.Id,
                    Page = 1,
                    Limit = 20
                };
                var rspDocuments = await _difyAIService.Datasets.GetDocumentsAsync(reqList);
                Assert.True(rspDocuments.Data.Count == 1);

                // delete document file
                await _difyAIService.Datasets.DeleteDocumentAsync(new DocumentDeleteRequest { DatasetId = rspDatasetCreate.Id, DocumentId = rspUpdate.Document.Id });

                // list documents in the dataset
                var rspDocuments2 = await _difyAIService.Datasets.GetDocumentsAsync(reqList);
                Assert.True(rspDocuments2.Data.Count == 0);
            }
            finally
            {
                //delete the dataset
                await _difyAIService.Datasets.DeleteDatasetAsync(new DatasetDeleteRequest { DatasetId = rspDatasetCreate.Id });
            }
        }

        [Fact]
        public async Task DatasetCreateAndUpdateDocumentByFile()
        {
            // create dataset
            var reqDatasetCreate = new DatasetCreateRequest
            {
                Name = $"test{DateTime.UtcNow.ToString("yyMMddhhmmss")}",
            };
            var rspDatasetCreate = await _difyAIService.Datasets.CreateDatasetAsync(reqDatasetCreate);
            Assert.NotNull(rspDatasetCreate.Id);

            try
            {
                //create document in the dataset
                var reqDocCreateDoc = new DocumentUpsetByFileRequest
                {
                    File = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Assets/Text1.txt"),
                    DatasetId = rspDatasetCreate.Id,
                    IndexingTechnique = DocumentUpsetByTextRequest.IndexingTechniqueEconomy,
                    ProcessRule = new DatasetProcessRule()
                    {
                        Mode = DatasetProcessRule.ModeAutomatic
                    }
                };
                var rspDocCreateDoc = await _difyAIService.Datasets.CreateDocumentByFileAsync(reqDocCreateDoc);
                Assert.NotNull(rspDocCreateDoc.Document.Id);

                var progressCompleted = false;
                var count = 0;
                var maxCount = 20;
                while (!progressCompleted && count < maxCount)
                {
                    await Task.Delay(500);
                    var embeddingRsp = await _difyAIService.Datasets.GetDocumentsEmbeddingAsync(new DocumentEmbeddingRequest { DatasetId = rspDatasetCreate.Id, Batch = rspDocCreateDoc.Batch });
                    if (embeddingRsp.Data[0].IndexingStatus == "completed")
                    {
                        progressCompleted = true;
                    }
                    else
                    {
                        count++;
                    }
                }
                Assert.True(progressCompleted);

                //update document in the dataset
                var reqUpdate = new DocumentUpdateByFileRequest
                {
                    File = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Assets/Text2.txt"),
                    DatasetId = rspDatasetCreate.Id,
                    DocumentId = rspDocCreateDoc.Document.Id,
                    IndexingTechnique = DocumentUpsetByTextRequest.IndexingTechniqueEconomy,
                    ProcessRule = new DatasetProcessRule()
                    {
                        Mode = DatasetProcessRule.ModeAutomatic
                    }
                };
                var rspUpdate = await _difyAIService.Datasets.UpdateDocumentByFileAsync(reqUpdate);
                Assert.Equal(rspDocCreateDoc.Document.Id, rspUpdate.Document.Id);

                // list documents in the dataset
                var reqList = new DocumentListRequest
                {
                    DatasetId = rspDatasetCreate.Id,
                    Page = 1,
                    Limit = 20
                };
                var rspDocuments = await _difyAIService.Datasets.GetDocumentsAsync(reqList);
                Assert.True(rspDocuments.Data.Count == 1);

                // delete document file
                await _difyAIService.Datasets.DeleteDocumentAsync(new DocumentDeleteRequest { DatasetId = rspDatasetCreate.Id, DocumentId = rspDocCreateDoc.Document.Id });

                // list documents in the dataset
                var rspDocuments2 = await _difyAIService.Datasets.GetDocumentsAsync(reqList);
                Assert.True(rspDocuments2.Data.Count == 0);
            }
            finally
            {
                //delete the dataset
                await _difyAIService.Datasets.DeleteDatasetAsync(new DatasetDeleteRequest { DatasetId = rspDatasetCreate.Id });
            }
        }

        [Fact]
        public async Task CreateAndUpdateDocumentSegments()
        {
            // create dataset
            var reqDatasetCreate = new DatasetCreateRequest
            {
                Name = $"test{DateTime.UtcNow.ToString("yyMMddHHmmssfff")}",
            };
            var rspDatasetCreate = await _difyAIService.Datasets.CreateDatasetAsync(reqDatasetCreate);

            try
            {
                //create document in the dataset
                var reqDocCreateTxt = new DocumentUpsetByTextRequest
                {
                    Name = "test_translate_doc_segment",
                    Text = "seg1",
                    DatasetId = rspDatasetCreate.Id,
                    IndexingTechnique = DocumentUpsetByTextRequest.IndexingTechniqueEconomy,
                    ProcessRule = new DatasetProcessRule()
                    {
                        Mode = DatasetProcessRule.ModeAutomatic
                    }
                };
                var rspDocCreateTxt = await _difyAIService.Datasets.CreateDocumentByTextAsync(reqDocCreateTxt);
                Assert.NotNull(rspDocCreateTxt.Document.Id);

                var progressCompleted = false;
                var count = 0;
                var maxCount = 20;
                while (!progressCompleted && count < maxCount)
                {
                    await Task.Delay(500);
                    var embeddingRsp = await _difyAIService.Datasets.GetDocumentsEmbeddingAsync(new DocumentEmbeddingRequest { DatasetId = rspDatasetCreate.Id, Batch = rspDocCreateTxt.Batch });
                    if (embeddingRsp.Data[0].IndexingStatus == "completed")
                    {
                        progressCompleted = true;
                    }
                    else
                    {
                        count++;
                    }
                }
                Assert.True(progressCompleted);

                // Add document segments to the document
                var reqDocSeg = new DocumentSegmentAddRequest
                {
                    DatasetId = rspDatasetCreate.Id,
                    DocumentId = rspDocCreateTxt.Document.Id,
                    Segments = new List<DocumentSegmentToAdd>
                    {
                        new DocumentSegmentToAdd
                        {
                            Content = "一",
                            Answer = "No.1",
                            Keywords = new List<string> { "1" }
                        },
                        new DocumentSegmentToAdd
                        {
                            Content = "二",
                            Answer = "No.2",
                            Keywords = new List<string> { "2" }
                        },
                        new DocumentSegmentToAdd
                        {
                            Content = "三",
                            Answer = "No.3",
                            Keywords = new List<string> { "3" }
                        },
                    }
                };
                var rspDocSeg = await _difyAIService.Datasets.AddDocumentSegmentsAsync(reqDocSeg);
                Assert.True(rspDocSeg.Data.Count == 3);

                // Update document segments
                var reqDocSegUpdate = new DocumentSegmentUpdateRequest
                {
                    DatasetId = rspDatasetCreate.Id,
                    DocumentId = rspDocCreateTxt.Document.Id,
                    SegmentId = rspDocSeg.Data[0].Id,
                    Segment = new DocumentSegmentToUpdate
                    {
                        Content = "一 更新",
                        Answer = "No.1 update",
                        Keywords = new List<string> { "1", "update" },
                        Enabled = true
                    }
                };
                var rspDocSegUpdate = await _difyAIService.Datasets.UpdateDocumentSegmentAsync(reqDocSegUpdate);
                Assert.Equal(rspDocSeg.Data[0].Id, rspDocSegUpdate.Data.Id);

                // List document segments
                var reqDocSegList = new DocumentSegmentListRequest
                {
                    DatasetId = rspDatasetCreate.Id,
                    DocumentId = rspDocCreateTxt.Document.Id,
                };

                var rspDocSegList = await _difyAIService.Datasets.GetDocumentSegmentsAsync(reqDocSegList);
                Assert.Equal(4, rspDocSegList.Data.Count);  //original create document will have 1 segment

                // Delete a document segment
                await _difyAIService.Datasets.DeleteDocumentSegmentAsync(new DocumentSegmentDeleteRequest { DatasetId = rspDatasetCreate.Id, DocumentId = rspDocCreateTxt.Document.Id, SegmentId = rspDocSeg.Data[0].Id });

                var rspDocSegList2 = await _difyAIService.Datasets.GetDocumentSegmentsAsync(reqDocSegList);
                Assert.Equal(3, rspDocSegList2.Data.Count);
            }
            finally
            {
                //delete the dataset
                await _difyAIService.Datasets.DeleteDatasetAsync(new DatasetDeleteRequest { DatasetId = rspDatasetCreate.Id });
            }
        }

        [Fact]
        public async Task GetDataset()
        {
            await _difyAIService.Datasets.GetDatasetAsync(new DatasetGetRequest
            {
                DatasetId = "2f89eb58-0103-41b4-b7f5-85b96c9af364"
            });
        }
    }
}
