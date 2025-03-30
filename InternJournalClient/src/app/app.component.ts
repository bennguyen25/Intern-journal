import { Component, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { JournalListComponent } from './components/journal-list/journal-list.component';
import { JournalFormComponent } from './components/journal-form/journal-form.component';
import { JournalEntry } from './services/journal.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, JournalListComponent, JournalFormComponent, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'InternJournalClient';
  
  selectedEntry: JournalEntry | null = null;
  presentationMode: boolean = false;

  @ViewChild(JournalListComponent) journalList!: JournalListComponent;

  handleEdit(entry: JournalEntry) {
    this.selectedEntry = entry;
  }

  handleRefresh() {
    this.journalList.loadEntries();
  }
}

