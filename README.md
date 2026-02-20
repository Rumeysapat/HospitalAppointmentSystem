🏥 Hospital Appointment System

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş bir hastane randevu sistemidir. Kullanıcılar bölüm, doktor ve uygun saat seçerek kolayca randevu oluşturabilir.

🚀 Özellikler

📌 Bölüme göre doktor listeleme

📅 Tarihe göre uygun saatleri getirme

⏱ 20 dakikalık randevu slotları (09:00 - 17:00)

👤 Email ile hasta oluşturma / kontrol etme

❌ Dolu saatleri engelleme

✅ Başarılı randevu sonrası yönlendirme

🧱 Proje Mimarisi

Proje N-Layer Architecture kullanılarak geliştirilmiştir:

Hospital.MVC        → UI (Controller + View)
Hospital.Services   → Business Layer
Hospital.Data       → Data Access Layer (EF Core)
Hospital.Entities   → Entity & DTO
Hospital.Shared     → Ortak yapılar (Result, Helpers vs.)
🛠 Kullanılan Teknolojiler

ASP.NET Core MVC (.NET 8)

Entity Framework Core

SQLite

jQuery / AJAX

Bootstrap / Tailwind (UI durumuna göre)

Repository Pattern

Unit of Work




Ekran görüntüleri

<img width="750" height="300" alt="Ekran Resmi 2026-02-20 12 40 42" src="https://github.com/user-attachments/assets/8adbea6a-8a18-4ca1-8b2d-27eaa1ea2580" />
<img width="750" height="300" alt="Ekran Resmi 2026-02-20 12 41 12" src="https://github.com/user-attachments/assets/dc56dc73-a8ec-4377-ae40-3638b31b7760" />
<img width="750" height="300" alt="Ekran Resmi 2026-02-20 12 41 23" src="https://github.com/user-attachments/assets/333a7d18-b79c-44dd-b44e-4c32107d20de" />
<img width="750" height="300" alt="Ekran Resmi 2026-02-20 12 41 39" src="https://github.com/user-attachments/assets/399999b6-3b65-4863-aa21-348f8a5ddd5b" />
<img width="750" height="300" alt="Ekran Resmi 2026-02-20 12 42 23" src="https://github.com/user-attachments/assets/ba31919b-7c80-4e7a-8a7e-3c6c6edb93b0" />

