
# Aplicación de consola.
# .NET 8.0

#Arquitectura 

ShiftPlanning.Application
│
├── Interfaces
│   ├── IEmailSender.cs
│   ├── IShiftImageProcessor.cs
│   └── IShiftMonitorService.cs
│
├── Services
│   ├── ShiftMonitorService.cs
│   ├── SmtpEmailSender.cs
│   └── (opcional) TestRunner.cs ← si quieres pruebas interactivas

ShiftPlanning.Console
└── Program.cs ← entry point con top-level statements

ShiftPlanning.Domain
└── Entities
    └── ShiftImage.cs

ShiftPlanning.Infrastructure
└── Services
    └── TesseractShiftImageProcessor.cs