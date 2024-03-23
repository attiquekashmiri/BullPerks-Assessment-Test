import { UtcToLocalDatePipe } from './utc-to-local-date.pipe';

describe('UtcToLocalDatePipe', () => {
  it('create an instance', () => {
    const pipe = new UtcToLocalDatePipe();
    expect(pipe).toBeTruthy();
  });
});
