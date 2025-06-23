using Microsoft.Extensions.DependencyInjection;
using ShiftPlanning.Application.Interfaces;
using ShiftPlanning.Application.Services;
using ShiftPlanning.Infrastructure.Services;

var services = new ServiceCollection();

// OCR config
string tessdataPath = @"C:\Program Files\Tesseract-OCR\tessdata";
services.AddSingleton<IShiftImageProcessor>(new TesseractShiftImageProcessor(tessdataPath));
services.AddSingleton<IEmailSender, SmtpEmailSender>();
services.AddSingleton<IShiftMonitorService, ShiftMonitorService>();

var provider = services.BuildServiceProvider();

var monitor = provider.GetRequiredService<IShiftMonitorService>();

// Rutas directas para prueba real
string folder = @"C:\Users\Andre\OneDrive\Desktop\Zurich\Aut_Scoober_H\captures\1";
string prev = Path.Combine(folder, "imag_previa.png");
string curr = Path.Combine(folder, "img_despues.png");

await monitor.RunMonitorCycleAsync(prev, curr, folder);
