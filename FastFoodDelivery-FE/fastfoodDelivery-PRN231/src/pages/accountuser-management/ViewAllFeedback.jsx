import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllFeedbacks } from '../../redux/features/ViewAllFeedback';
import { Table } from 'antd';

const ViewAllFeedback = () => {
  const dispatch = useDispatch();
  const { feedbacks, status, error } = useSelector(state => state.feedback);

  useEffect(() => {
    dispatch(fetchAllFeedbacks());
  }, [dispatch]);

  if (status === 'loading') {
    return <div>Loading...</div>;
  }

  if (status === 'failed') {
    return <div>{error}</div>;
  }

  return (
    <div className="container mt-3">
      <h2>All Feedback</h2>
      <Table dataSource={feedbacks} rowKey="feedBackId">
        <Table.Column title="User ID" dataIndex="userId" key="userId" />
        <Table.Column title="Order ID" dataIndex="orderId" key="orderId" />
        <Table.Column title="Comment" dataIndex="commentMsg" key="commentMsg" />
      </Table>
    </div>
  );
};

export default ViewAllFeedback;
