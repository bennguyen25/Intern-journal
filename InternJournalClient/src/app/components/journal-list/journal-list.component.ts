import { Component, OnInit } from '@angular/core';
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
  entries: JournalEntry[] = [];

  constructor(private journalService: JournalService) {}

  ngOnInit(): void {
    this.journalService.getEntries().subscribe((data) => {
      this.entries = data;
    });
  }
}
