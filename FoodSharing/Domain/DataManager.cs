using IESE.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSharing.Domain
{
    public class DataManager
    {
        public IWordDocumentRepository WordDocument { get; set; }
        public IWordTemplateRepository WordTepmlate { get; set; }
        public IDocumentCategoryRepository DocumentCategory { get; set; }

        public DataManager(IWordDocumentRepository wordDocumentRepository, IWordTemplateRepository templateRepository,
                            IDocumentCategoryRepository documentCategoryRepository)
        {
            WordDocument = wordDocumentRepository;
            WordTepmlate = templateRepository;
            DocumentCategory = documentCategoryRepository;
        }
    }
}
