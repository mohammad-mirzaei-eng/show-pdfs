# Show PDF

This project is a Windows Forms application that allows users to view PDF files. It is built using .NET 8 and utilizes the PdfiumViewer library for rendering PDF documents.

## Features

- Open and view PDF files
- Navigate through pages
- Zoom in and out
- Search text within the PDF

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022

## Getting Started

1. Clone the repository: git clone https://github.com/mohammad-mirzaei-eng/show-pdfs.git
2. Open the solution in Visual Studio 2022.
3. Restore the NuGet packages:
4. Build and run the application.

## Dependencies

This project uses the following NuGet packages:

- [PdfiumViewer](https://www.nuget.org/packages/PdfiumViewer/) - A PDF viewer based on the PDFium library.
- [PdfiumViewer.Native.x86_64.v8-xfa](https://www.nuget.org/packages/PdfiumViewer.Native.x86_64.v8-xfa/) - Native PDFium binaries for x86_64 architecture with XFA support.

## Project Structure

- `show_pdf.csproj` - Project file containing the configuration and dependencies.
- `Program.cs` - Entry point of the application.
- `MainForm.cs` - Main form of the application where the PDF viewer is hosted.

## Usage

1. Launch the application.
2. Use the "Open" button to select a PDF file.
3. Navigate through the PDF using the provided controls.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

# نمایش PDF

این پروژه یک برنامه ویندوز فرم است که به کاربران اجازه می‌دهد فایل‌های PDF را مشاهده کنند. این برنامه با استفاده از .NET 8 ساخته شده و از کتابخانه PdfiumViewer برای رندر کردن اسناد PDF استفاده می‌کند.

## ویژگی‌ها

- باز کردن و مشاهده فایل‌های PDF
- پیمایش در صفحات
- بزرگنمایی و کوچک‌نمایی
- جستجوی متن در داخل PDF

## پیش‌نیازها

- .NET 8 SDK
- Visual Studio 2022

## شروع به کار

1. مخزن را کلون کنید: git clone https://github.com/mohammad-mirzaei-eng/show-pdfs.git
2. راه‌حل را در Visual Studio 2022 باز کنید.
3. بسته‌های NuGet را بازیابی کنید:
4. برنامه را بسازید و اجرا کنید.

## وابستگی‌ها

این پروژه از بسته‌های NuGet زیر استفاده می‌کند:

- [PdfiumViewer](https://www.nuget.org/packages/PdfiumViewer/) - یک نمایشگر PDF مبتنی بر کتابخانه PDFium.
- [PdfiumViewer.Native.x86_64.v8-xfa](https://www.nuget.org/packages/PdfiumViewer.Native.x86_64.v8-xfa/) - باینری‌های بومی PDFium برای معماری x86_64 با پشتیبانی از XFA.

## ساختار پروژه

- `show_pdf.csproj` - فایل پروژه که شامل پیکربندی و وابستگی‌ها است.
- `Program.cs` - نقطه ورود برنامه.
- `MainForm.cs` - فرم اصلی برنامه که نمایشگر PDF در آن قرار دارد.

## استفاده

1. برنامه را اجرا کنید.
2. از دکمه "باز کردن" برای انتخاب یک فایل PDF استفاده کنید.
3. با استفاده از کنترل‌های موجود در PDF پیمایش کنید.

## مشارکت

مشارکت‌ها خوش‌آمد می‌باشند! لطفاً مخزن را فورک کنید و یک درخواست کشش ارسال کنید.

## مجوز

این پروژه تحت مجوز MIT مجوز دارد. برای جزئیات به فایل [LICENSE](LICENSE) مراجعه کنید.
