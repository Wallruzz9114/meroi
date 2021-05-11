import * as Apollo from '@apollo/client';
import { gql } from '@apollo/client';
export type Maybe<T> = T | null;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
const defaultOptions = {};
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  /** The `DateTime` scalar represents an ISO-8601 compliant date time type. */
  DateTime: any;
};

export type AddOrderInput = {
  orderDate: Scalars['DateTime'];
};

export type AddOrderItemInput = {
  orderId: Scalars['Int'];
  productId: Scalars['Int'];
  count: Scalars['Int'];
};

export type AddOrderItemPayload = {
  __typename?: 'AddOrderItemPayload';
  orderItem?: Maybe<OrderItem>;
  errors?: Maybe<Array<UserError>>;
};

export type AddOrderPayload = {
  __typename?: 'AddOrderPayload';
  order?: Maybe<Order>;
  errors?: Maybe<Array<UserError>>;
};

export type AddProductInput = {
  name: Scalars['String'];
  price: Scalars['Float'];
  type: Scalars['String'];
  description: Scalars['String'];
  imgUrl: Scalars['String'];
};

export type AddProductPayload = {
  __typename?: 'AddProductPayload';
  product?: Maybe<Product>;
  errors?: Maybe<Array<UserError>>;
};

export type AddUserInput = {
  name: Scalars['String'];
  email: Scalars['String'];
  password: Scalars['String'];
  address: Scalars['String'];
};

export type AddUserOrderInput = {
  userId: Scalars['Int'];
  orderIds: Array<Scalars['Int']>;
};

export type AddUserOrderPayload = {
  __typename?: 'AddUserOrderPayload';
  user?: Maybe<User>;
  errors?: Maybe<Array<UserError>>;
};

export type AddUserPayload = {
  __typename?: 'AddUserPayload';
  user?: Maybe<User>;
  errors?: Maybe<Array<UserError>>;
};

export enum ApplyPolicy {
  BeforeResolver = 'BEFORE_RESOLVER',
  AfterResolver = 'AFTER_RESOLVER',
}

/** Represents the mutations */
export type Mutations = {
  __typename?: 'Mutations';
  register?: Maybe<AddUserPayload>;
  addUsersOrder?: Maybe<AddUserOrderPayload>;
  addOrder?: Maybe<AddOrderPayload>;
  addProduct?: Maybe<AddProductPayload>;
  addOrderItem?: Maybe<AddOrderItemPayload>;
};

/** Represents the mutations */
export type MutationsRegisterArgs = {
  input?: Maybe<AddUserInput>;
};

/** Represents the mutations */
export type MutationsAddUsersOrderArgs = {
  input?: Maybe<AddUserOrderInput>;
};

/** Represents the mutations */
export type MutationsAddOrderArgs = {
  input?: Maybe<AddOrderInput>;
};

/** Represents the mutations */
export type MutationsAddProductArgs = {
  input?: Maybe<AddProductInput>;
};

/** Represents the mutations */
export type MutationsAddOrderItemArgs = {
  input?: Maybe<AddOrderItemInput>;
};

export type Order = {
  __typename?: 'Order';
  users?: Maybe<Array<Maybe<User>>>;
  orderItems?: Maybe<Array<Maybe<OrderItem>>>;
  orderDate: Scalars['DateTime'];
  id: Scalars['Int'];
};

export type OrderItem = {
  __typename?: 'OrderItem';
  orderId: Scalars['Int'];
  order?: Maybe<Order>;
  productId: Scalars['Int'];
  product?: Maybe<Product>;
  count: Scalars['Int'];
  id: Scalars['Int'];
  createdAt: Scalars['DateTime'];
  updatedAt?: Maybe<Scalars['DateTime']>;
  lastAccessedAt: Scalars['DateTime'];
};

export type Product = {
  __typename?: 'Product';
  name: Scalars['String'];
  price: Scalars['Float'];
  type: Scalars['String'];
  description: Scalars['String'];
  imgUrl: Scalars['String'];
  id: Scalars['Int'];
  createdAt: Scalars['DateTime'];
  updatedAt?: Maybe<Scalars['DateTime']>;
  lastAccessedAt: Scalars['DateTime'];
};

/** Represents the queries. */
export type Queries = {
  __typename?: 'Queries';
  /** Represents the query to get all users. */
  users?: Maybe<Array<Maybe<User>>>;
  user?: Maybe<User>;
  /** Represents the query to get all orders. */
  orders?: Maybe<Array<Maybe<Order>>>;
  /** Represents the query to get an order by id. */
  order?: Maybe<Order>;
  orderItems?: Maybe<Array<Maybe<OrderItem>>>;
  orderItem?: Maybe<OrderItem>;
  products?: Maybe<Array<Maybe<Product>>>;
  product?: Maybe<Product>;
};

/** Represents the queries. */
export type QueriesUserArgs = {
  id: Scalars['ID'];
};

/** Represents the queries. */
export type QueriesOrderArgs = {
  id: Scalars['Int'];
};

/** Represents the queries. */
export type QueriesOrderItemArgs = {
  id: Scalars['Int'];
};

/** Represents the queries. */
export type QueriesProductArgs = {
  id: Scalars['Int'];
};

/** Represents a User entity. */
export type User = {
  __typename?: 'User';
  /** Represents the user's id */
  id: Scalars['Int'];
  /** Represents the user's orders */
  orders?: Maybe<Array<Maybe<Order>>>;
  /** Represents the user's email */
  email: Scalars['String'];
  /** Represents the user's name */
  name: Scalars['String'];
  password: Scalars['String'];
  address: Scalars['String'];
};

export type UserError = {
  __typename?: 'UserError';
  message?: Maybe<Scalars['String']>;
  code?: Maybe<Scalars['String']>;
};

export type AddOrderMutationVariables = Exact<{
  input: AddOrderInput;
}>;

export type AddOrderMutation = { __typename?: 'Mutations' } & {
  addOrder?: Maybe<
    { __typename?: 'AddOrderPayload' } & {
      order?: Maybe<{ __typename?: 'Order' } & Pick<Order, 'id'>>;
    }
  >;
};

export type AddOrderItemMutationVariables = Exact<{
  input: AddOrderItemInput;
}>;

export type AddOrderItemMutation = { __typename?: 'Mutations' } & {
  addOrderItem?: Maybe<
    { __typename?: 'AddOrderItemPayload' } & {
      orderItem?: Maybe<{ __typename?: 'OrderItem' } & Pick<OrderItem, 'id'>>;
    }
  >;
};

export type AddProductMutationVariables = Exact<{
  input: AddProductInput;
}>;

export type AddProductMutation = { __typename?: 'Mutations' } & {
  addProduct?: Maybe<
    { __typename?: 'AddProductPayload' } & {
      product?: Maybe<{ __typename?: 'Product' } & Pick<Product, 'id'>>;
    }
  >;
};

export type AddUsersOrderMutationVariables = Exact<{
  input: AddUserOrderInput;
}>;

export type AddUsersOrderMutation = { __typename?: 'Mutations' } & {
  addUsersOrder?: Maybe<
    { __typename?: 'AddUserOrderPayload' } & {
      user?: Maybe<{ __typename?: 'User' } & Pick<User, 'id'>>;
    }
  >;
};

export type RegisterMutationVariables = Exact<{
  input: AddUserInput;
}>;

export type RegisterMutation = { __typename?: 'Mutations' } & {
  register?: Maybe<
    { __typename?: 'AddUserPayload' } & { user?: Maybe<{ __typename?: 'User' } & Pick<User, 'id'>> }
  >;
};

export type OrderQueryVariables = Exact<{
  id: Scalars['Int'];
}>;

export type OrderQuery = { __typename?: 'Queries' } & {
  order?: Maybe<{ __typename?: 'Order' } & Pick<Order, 'id' | 'orderDate'>>;
};

export type OrderItemQueryVariables = Exact<{
  id: Scalars['Int'];
}>;

export type OrderItemQuery = { __typename?: 'Queries' } & {
  orderItem?: Maybe<
    { __typename?: 'OrderItem' } & Pick<OrderItem, 'id' | 'productId' | 'orderId' | 'count'>
  >;
};

export type OrderItemsQueryVariables = Exact<{ [key: string]: never }>;

export type OrderItemsQuery = { __typename?: 'Queries' } & {
  orderItems?: Maybe<
    Array<
      Maybe<
        { __typename?: 'OrderItem' } & Pick<OrderItem, 'id' | 'productId' | 'orderId' | 'count'>
      >
    >
  >;
};

export type OrdersQueryVariables = Exact<{ [key: string]: never }>;

export type OrdersQuery = { __typename?: 'Queries' } & {
  orders?: Maybe<Array<Maybe<{ __typename?: 'Order' } & Pick<Order, 'id' | 'orderDate'>>>>;
};

export type ProductQueryVariables = Exact<{
  id: Scalars['Int'];
}>;

export type ProductQuery = { __typename?: 'Queries' } & {
  product?: Maybe<{ __typename?: 'Product' } & Pick<Product, 'name' | 'price'>>;
};

export type ProductsQueryVariables = Exact<{ [key: string]: never }>;

export type ProductsQuery = { __typename?: 'Queries' } & {
  products?: Maybe<Array<Maybe<{ __typename?: 'Product' } & Pick<Product, 'name' | 'price'>>>>;
};

export type UserQueryVariables = Exact<{
  id: Scalars['ID'];
}>;

export type UserQuery = { __typename?: 'Queries' } & {
  user?: Maybe<{ __typename?: 'User' } & Pick<User, 'name' | 'email'>>;
};

export type UsersQueryVariables = Exact<{ [key: string]: never }>;

export type UsersQuery = { __typename?: 'Queries' } & {
  users?: Maybe<Array<Maybe<{ __typename?: 'User' } & Pick<User, 'name' | 'email'>>>>;
};

export const AddOrderDocument = gql`
  mutation addOrder($input: AddOrderInput!) {
    addOrder(input: $input) {
      order {
        id
      }
    }
  }
`;
export type AddOrderMutationFn = Apollo.MutationFunction<
  AddOrderMutation,
  AddOrderMutationVariables
>;

/**
 * __useAddOrderMutation__
 *
 * To run a mutation, you first call `useAddOrderMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useAddOrderMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [addOrderMutation, { data, loading, error }] = useAddOrderMutation({
 *   variables: {
 *      input: // value for 'input'
 *   },
 * });
 */
export function useAddOrderMutation(
  baseOptions?: Apollo.MutationHookOptions<AddOrderMutation, AddOrderMutationVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useMutation<AddOrderMutation, AddOrderMutationVariables>(AddOrderDocument, options);
}
export type AddOrderMutationHookResult = ReturnType<typeof useAddOrderMutation>;
export type AddOrderMutationResult = Apollo.MutationResult<AddOrderMutation>;
export type AddOrderMutationOptions = Apollo.BaseMutationOptions<
  AddOrderMutation,
  AddOrderMutationVariables
>;
export const AddOrderItemDocument = gql`
  mutation addOrderItem($input: AddOrderItemInput!) {
    addOrderItem(input: $input) {
      orderItem {
        id
      }
    }
  }
`;
export type AddOrderItemMutationFn = Apollo.MutationFunction<
  AddOrderItemMutation,
  AddOrderItemMutationVariables
>;

/**
 * __useAddOrderItemMutation__
 *
 * To run a mutation, you first call `useAddOrderItemMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useAddOrderItemMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [addOrderItemMutation, { data, loading, error }] = useAddOrderItemMutation({
 *   variables: {
 *      input: // value for 'input'
 *   },
 * });
 */
export function useAddOrderItemMutation(
  baseOptions?: Apollo.MutationHookOptions<AddOrderItemMutation, AddOrderItemMutationVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useMutation<AddOrderItemMutation, AddOrderItemMutationVariables>(
    AddOrderItemDocument,
    options
  );
}
export type AddOrderItemMutationHookResult = ReturnType<typeof useAddOrderItemMutation>;
export type AddOrderItemMutationResult = Apollo.MutationResult<AddOrderItemMutation>;
export type AddOrderItemMutationOptions = Apollo.BaseMutationOptions<
  AddOrderItemMutation,
  AddOrderItemMutationVariables
>;
export const AddProductDocument = gql`
  mutation addProduct($input: AddProductInput!) {
    addProduct(input: $input) {
      product {
        id
      }
    }
  }
`;
export type AddProductMutationFn = Apollo.MutationFunction<
  AddProductMutation,
  AddProductMutationVariables
>;

/**
 * __useAddProductMutation__
 *
 * To run a mutation, you first call `useAddProductMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useAddProductMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [addProductMutation, { data, loading, error }] = useAddProductMutation({
 *   variables: {
 *      input: // value for 'input'
 *   },
 * });
 */
export function useAddProductMutation(
  baseOptions?: Apollo.MutationHookOptions<AddProductMutation, AddProductMutationVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useMutation<AddProductMutation, AddProductMutationVariables>(
    AddProductDocument,
    options
  );
}
export type AddProductMutationHookResult = ReturnType<typeof useAddProductMutation>;
export type AddProductMutationResult = Apollo.MutationResult<AddProductMutation>;
export type AddProductMutationOptions = Apollo.BaseMutationOptions<
  AddProductMutation,
  AddProductMutationVariables
>;
export const AddUsersOrderDocument = gql`
  mutation addUsersOrder($input: AddUserOrderInput!) {
    addUsersOrder(input: $input) {
      user {
        id
      }
    }
  }
`;
export type AddUsersOrderMutationFn = Apollo.MutationFunction<
  AddUsersOrderMutation,
  AddUsersOrderMutationVariables
>;

/**
 * __useAddUsersOrderMutation__
 *
 * To run a mutation, you first call `useAddUsersOrderMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useAddUsersOrderMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [addUsersOrderMutation, { data, loading, error }] = useAddUsersOrderMutation({
 *   variables: {
 *      input: // value for 'input'
 *   },
 * });
 */
export function useAddUsersOrderMutation(
  baseOptions?: Apollo.MutationHookOptions<AddUsersOrderMutation, AddUsersOrderMutationVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useMutation<AddUsersOrderMutation, AddUsersOrderMutationVariables>(
    AddUsersOrderDocument,
    options
  );
}
export type AddUsersOrderMutationHookResult = ReturnType<typeof useAddUsersOrderMutation>;
export type AddUsersOrderMutationResult = Apollo.MutationResult<AddUsersOrderMutation>;
export type AddUsersOrderMutationOptions = Apollo.BaseMutationOptions<
  AddUsersOrderMutation,
  AddUsersOrderMutationVariables
>;
export const RegisterDocument = gql`
  mutation register($input: AddUserInput!) {
    register(input: $input) {
      user {
        id
      }
    }
  }
`;
export type RegisterMutationFn = Apollo.MutationFunction<
  RegisterMutation,
  RegisterMutationVariables
>;

/**
 * __useRegisterMutation__
 *
 * To run a mutation, you first call `useRegisterMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useRegisterMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [registerMutation, { data, loading, error }] = useRegisterMutation({
 *   variables: {
 *      input: // value for 'input'
 *   },
 * });
 */
export function useRegisterMutation(
  baseOptions?: Apollo.MutationHookOptions<RegisterMutation, RegisterMutationVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useMutation<RegisterMutation, RegisterMutationVariables>(RegisterDocument, options);
}
export type RegisterMutationHookResult = ReturnType<typeof useRegisterMutation>;
export type RegisterMutationResult = Apollo.MutationResult<RegisterMutation>;
export type RegisterMutationOptions = Apollo.BaseMutationOptions<
  RegisterMutation,
  RegisterMutationVariables
>;
export const OrderDocument = gql`
  query order($id: Int!) {
    order(id: $id) {
      id
      orderDate
    }
  }
`;

/**
 * __useOrderQuery__
 *
 * To run a query within a React component, call `useOrderQuery` and pass it any options that fit your needs.
 * When your component renders, `useOrderQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useOrderQuery({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useOrderQuery(
  baseOptions: Apollo.QueryHookOptions<OrderQuery, OrderQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<OrderQuery, OrderQueryVariables>(OrderDocument, options);
}
export function useOrderLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<OrderQuery, OrderQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<OrderQuery, OrderQueryVariables>(OrderDocument, options);
}
export type OrderQueryHookResult = ReturnType<typeof useOrderQuery>;
export type OrderLazyQueryHookResult = ReturnType<typeof useOrderLazyQuery>;
export type OrderQueryResult = Apollo.QueryResult<OrderQuery, OrderQueryVariables>;
export const OrderItemDocument = gql`
  query orderItem($id: Int!) {
    orderItem(id: $id) {
      id
      productId
      orderId
      count
    }
  }
`;

/**
 * __useOrderItemQuery__
 *
 * To run a query within a React component, call `useOrderItemQuery` and pass it any options that fit your needs.
 * When your component renders, `useOrderItemQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useOrderItemQuery({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useOrderItemQuery(
  baseOptions: Apollo.QueryHookOptions<OrderItemQuery, OrderItemQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<OrderItemQuery, OrderItemQueryVariables>(OrderItemDocument, options);
}
export function useOrderItemLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<OrderItemQuery, OrderItemQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<OrderItemQuery, OrderItemQueryVariables>(OrderItemDocument, options);
}
export type OrderItemQueryHookResult = ReturnType<typeof useOrderItemQuery>;
export type OrderItemLazyQueryHookResult = ReturnType<typeof useOrderItemLazyQuery>;
export type OrderItemQueryResult = Apollo.QueryResult<OrderItemQuery, OrderItemQueryVariables>;
export const OrderItemsDocument = gql`
  query orderItems {
    orderItems {
      id
      productId
      orderId
      count
    }
  }
`;

/**
 * __useOrderItemsQuery__
 *
 * To run a query within a React component, call `useOrderItemsQuery` and pass it any options that fit your needs.
 * When your component renders, `useOrderItemsQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useOrderItemsQuery({
 *   variables: {
 *   },
 * });
 */
export function useOrderItemsQuery(
  baseOptions?: Apollo.QueryHookOptions<OrderItemsQuery, OrderItemsQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<OrderItemsQuery, OrderItemsQueryVariables>(OrderItemsDocument, options);
}
export function useOrderItemsLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<OrderItemsQuery, OrderItemsQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<OrderItemsQuery, OrderItemsQueryVariables>(
    OrderItemsDocument,
    options
  );
}
export type OrderItemsQueryHookResult = ReturnType<typeof useOrderItemsQuery>;
export type OrderItemsLazyQueryHookResult = ReturnType<typeof useOrderItemsLazyQuery>;
export type OrderItemsQueryResult = Apollo.QueryResult<OrderItemsQuery, OrderItemsQueryVariables>;
export const OrdersDocument = gql`
  query orders {
    orders {
      id
      orderDate
    }
  }
`;

/**
 * __useOrdersQuery__
 *
 * To run a query within a React component, call `useOrdersQuery` and pass it any options that fit your needs.
 * When your component renders, `useOrdersQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useOrdersQuery({
 *   variables: {
 *   },
 * });
 */
export function useOrdersQuery(
  baseOptions?: Apollo.QueryHookOptions<OrdersQuery, OrdersQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<OrdersQuery, OrdersQueryVariables>(OrdersDocument, options);
}
export function useOrdersLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<OrdersQuery, OrdersQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<OrdersQuery, OrdersQueryVariables>(OrdersDocument, options);
}
export type OrdersQueryHookResult = ReturnType<typeof useOrdersQuery>;
export type OrdersLazyQueryHookResult = ReturnType<typeof useOrdersLazyQuery>;
export type OrdersQueryResult = Apollo.QueryResult<OrdersQuery, OrdersQueryVariables>;
export const ProductDocument = gql`
  query product($id: Int!) {
    product(id: $id) {
      name
      price
    }
  }
`;

/**
 * __useProductQuery__
 *
 * To run a query within a React component, call `useProductQuery` and pass it any options that fit your needs.
 * When your component renders, `useProductQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useProductQuery({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useProductQuery(
  baseOptions: Apollo.QueryHookOptions<ProductQuery, ProductQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<ProductQuery, ProductQueryVariables>(ProductDocument, options);
}
export function useProductLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<ProductQuery, ProductQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<ProductQuery, ProductQueryVariables>(ProductDocument, options);
}
export type ProductQueryHookResult = ReturnType<typeof useProductQuery>;
export type ProductLazyQueryHookResult = ReturnType<typeof useProductLazyQuery>;
export type ProductQueryResult = Apollo.QueryResult<ProductQuery, ProductQueryVariables>;
export const ProductsDocument = gql`
  query products {
    products {
      name
      price
    }
  }
`;

/**
 * __useProductsQuery__
 *
 * To run a query within a React component, call `useProductsQuery` and pass it any options that fit your needs.
 * When your component renders, `useProductsQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useProductsQuery({
 *   variables: {
 *   },
 * });
 */
export function useProductsQuery(
  baseOptions?: Apollo.QueryHookOptions<ProductsQuery, ProductsQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<ProductsQuery, ProductsQueryVariables>(ProductsDocument, options);
}
export function useProductsLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<ProductsQuery, ProductsQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<ProductsQuery, ProductsQueryVariables>(ProductsDocument, options);
}
export type ProductsQueryHookResult = ReturnType<typeof useProductsQuery>;
export type ProductsLazyQueryHookResult = ReturnType<typeof useProductsLazyQuery>;
export type ProductsQueryResult = Apollo.QueryResult<ProductsQuery, ProductsQueryVariables>;
export const UserDocument = gql`
  query user($id: ID!) {
    user(id: $id) {
      name
      email
    }
  }
`;

/**
 * __useUserQuery__
 *
 * To run a query within a React component, call `useUserQuery` and pass it any options that fit your needs.
 * When your component renders, `useUserQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useUserQuery({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useUserQuery(baseOptions: Apollo.QueryHookOptions<UserQuery, UserQueryVariables>) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<UserQuery, UserQueryVariables>(UserDocument, options);
}
export function useUserLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<UserQuery, UserQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<UserQuery, UserQueryVariables>(UserDocument, options);
}
export type UserQueryHookResult = ReturnType<typeof useUserQuery>;
export type UserLazyQueryHookResult = ReturnType<typeof useUserLazyQuery>;
export type UserQueryResult = Apollo.QueryResult<UserQuery, UserQueryVariables>;
export const UsersDocument = gql`
  query users {
    users {
      name
      email
    }
  }
`;

/**
 * __useUsersQuery__
 *
 * To run a query within a React component, call `useUsersQuery` and pass it any options that fit your needs.
 * When your component renders, `useUsersQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useUsersQuery({
 *   variables: {
 *   },
 * });
 */
export function useUsersQuery(
  baseOptions?: Apollo.QueryHookOptions<UsersQuery, UsersQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<UsersQuery, UsersQueryVariables>(UsersDocument, options);
}
export function useUsersLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<UsersQuery, UsersQueryVariables>
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<UsersQuery, UsersQueryVariables>(UsersDocument, options);
}
export type UsersQueryHookResult = ReturnType<typeof useUsersQuery>;
export type UsersLazyQueryHookResult = ReturnType<typeof useUsersLazyQuery>;
export type UsersQueryResult = Apollo.QueryResult<UsersQuery, UsersQueryVariables>;
