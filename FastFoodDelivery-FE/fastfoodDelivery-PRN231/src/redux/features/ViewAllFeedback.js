import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import axios from 'axios';

// Thunk to fetch all feedbacks
export const fetchAllFeedbacks = createAsyncThunk(
  'feedback/fetchAllFeedbacks',
  async () => {
    const response = await axios.get('https://localhost:7173/api/FeedBacks/ViewAllFeedBack');
    return response.data;
  }
);

const feedbackSlice = createSlice({
  name: 'feedback',
  initialState: {
    feedbacks: [],
    status: 'idle',
    error: null,
  },
  extraReducers: builder => {
    builder
      .addCase(fetchAllFeedbacks.pending, state => {
        state.status = 'loading';
      })
      .addCase(fetchAllFeedbacks.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.feedbacks = action.payload.data || [];
      })
      .addCase(fetchAllFeedbacks.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.error.message;
      });
  },
});

export default feedbackSlice.reducer;
