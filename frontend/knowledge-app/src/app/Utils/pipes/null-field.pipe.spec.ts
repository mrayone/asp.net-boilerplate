import { NullFieldPipe } from './null-field.pipe';

describe('NullFieldPipe', () => {
  it('create an instance', () => {
    const pipe = new NullFieldPipe();
    expect(pipe).toBeTruthy();
  });
});
