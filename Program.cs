using Microsoft.Extensions.DependencyInjection;
using ShiftPlanning.Application.Interfaces;
using ShiftPlanning.Application.Services;
using ShiftPlanning.Infrastructure.Services;
using ShiftPlanning.Infrastructure;

var services = new ServiceCollection();

// Ruta donde tienes el directorio "tessdata"
string tessdataPath = @"C:\Program Files\Tesseract-OCR\tessdata";

// Registrar servicios
services.AddSingleton<IShiftImageProcessor>(new TesseractShiftImageProcessor(tessdataPath));
services.AddSingleton<IShiftMonitorService, ShiftMonitorService>();
services.AddSingleton<ShiftPlanning.Infrastructure.Services.ShiftPlannerEngine>();

var serviceProvider = services.BuildServiceProvider();

// Ruta de prueba
string prevImage = @"captures\\1\\imag_previa.png";
string currImage = @"captures\\1\\img_despues.png";
string outputFolder = @"captures\\1";

var engine = serviceProvider.GetRequiredService<ShiftPlanning.Infrastructure.Services.ShiftPlannerEngine>();
await engine.CompareAndLogAsync(prevImage, currImage, outputFolder);
