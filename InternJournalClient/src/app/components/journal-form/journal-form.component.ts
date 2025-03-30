import { Component, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { JournalService, JournalEntry } from '../../services/journal.service';


@Component({
  selector: 'app-journal-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './journal-form.component.html',
  styleUrls: ['./journal-form.component.css']
})

export class JournalFormComponent implements OnChanges {
  newEntry: Partial<JournalEntry> = {
    title: '',
    body: '',
    mood: '',
    tags: [],
    date: ''
  };

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['editingEntry'] && this.editingEntry) {
      this.newEntry = { ...this.editingEntry };
    }
  }

  tagInput = '';

  @Input() editingEntry: JournalEntry | null = null;

  @Output() refreshList = new EventEmitter<void>();

  constructor(private journalService: JournalService) {}

  addTag() {
    if (this.tagInput.trim()) {
      this.newEntry.tags = [...(this.newEntry.tags || []), this.tagInput.trim()];
      this.tagInput = '';
    }
  }

  submitEntry() {
    if (!this.newEntry.title || !this.newEntry.body || !this.newEntry.mood) return;
  
    const payload = {
      ...this.newEntry,
      date: new Date().toISOString()
    };
  
    this.journalService.createEntry(payload as JournalEntry).subscribe(() => {
      alert('Entry created!');
      this.newEntry = { title: '', body: '', mood: '', tags: [], date: '' };
      this.refreshList.emit(); // notify parent to refresh the list
    });
  }

  updateEntry() {
    if (!this.newEntry || !this.newEntry.id) return;
  
    this.journalService.updateEntry(this.newEntry as JournalEntry).subscribe(() => {
      alert('Entry updated!');
      this.newEntry = { title: '', body: '', mood: '', tags: [], date: '' };
      this.editingEntry = null;
      this.refreshList.emit(); // notify parent to refresh the list
    });
  }
}
