import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface JournalEntry {
  id: number;
  title: string;
  body: string;
  mood: string;
  tags: string[];
  date: string;
}

@Injectable({
  providedIn: 'root'
})
export class JournalService {
  private apiUrl = 'http://localhost:5251/api/entry';

  constructor(private http: HttpClient) {}

  getEntries(): Observable<JournalEntry[]> {
    return this.http.get<JournalEntry[]>(this.apiUrl);
  }

  createEntry(entry: JournalEntry): Observable<JournalEntry> {
    return this.http.post<JournalEntry>(this.apiUrl, entry);
  }

  updateEntry(entry: JournalEntry): Observable<JournalEntry> {
    return this.http.put<JournalEntry>(`${this.apiUrl}/${entry.id}`, entry);
  }

  deleteEntry(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
