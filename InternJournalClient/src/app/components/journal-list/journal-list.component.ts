import { Component, EventEmitter, Output, OnInit, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JournalService, JournalEntry } from '../../services/journal.service';

@Component({
  selector: 'app-journal-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './journal-list.component.html',
  styleUrls: ['./journal-list.component.css']
})
export class JournalListComponent implements OnInit {
  @Input() presentationMode: boolean = false;

  entries: JournalEntry[] = [];
  @Output() editEntry = new EventEmitter<JournalEntry>();

  constructor(private journalService: JournalService) {}

  ngOnInit(): void {
    this.loadEntries();
  }

  loadEntries() {
    this.journalService.getEntries().subscribe((data) => {
      this.entries = data;
    });
  }

  onEdit(entry: JournalEntry) {
    this.editEntry.emit(entry);
    this.loadEntries();
  }

  onDelete(entry: JournalEntry) {
    if (confirm(`Are you sure you want to delete "${entry.title}"?`)) {
      this.journalService.deleteEntry(entry.id).subscribe(() => {
        alert('Entry deleted!');
        this.loadEntries();
      });
    }
  }
}
