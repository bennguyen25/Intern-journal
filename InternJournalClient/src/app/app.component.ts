import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { JournalListComponent } from './components/journal-list/journal-list.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, JournalListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'InternJournalClient';
}
